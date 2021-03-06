using System;
using System.Collections.Generic;
using System.Text;
using CryoLib;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;


namespace Persistence {
	public class API {
		Configuration cfg;
		ISessionFactory factory;

		public API() {
			cfg = new Configuration();
			cfg.AddAssembly("Persistence");
			factory = cfg.BuildSessionFactory();
		}

		public int NewLogin(string email) {
			int answer = 0;

			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

					// Check whether this email address is already in use
				ICriteria criterion = session.CreateCriteria(typeof(P_User));
				criterion.Add(Expression.Eq("EmailAddr", email));
				System.Collections.IList userList = criterion.List();
				if (userList.Count == 0) {
					// Create new user and save to the database
					P_User user = new P_User(email);
					session.Save(user);
					answer = user.Id;
				}
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
					throw;
				}
			} finally {
				if (session != null) {
					session.Close();
				}
			}
			return answer;
		}

		public int Login(string email) {
			int answer = 0;

			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				ICriteria criterion = session.CreateCriteria(typeof(P_User));
				criterion.Add(Expression.Eq("EmailAddr", email));
				System.Collections.IList userList = criterion.List();
				switch (userList.Count) {
					case 0:
						// Return 0 to indicate that no user exists for the given email addess
						answer = 0;
						break;
					case 1:
						// Generate a new episode for this login session
						P_User user = (P_User)userList[0];
						user.LastLogin = DateTime.Now;
						if (user.OpenEpisode != null) {
							user.OpenEpisode.Close();
							user.OpenEpisode = null;
						}
						answer = user.Id;
						break;
					default:
						// Error
						string msg = string.Format("Internal Error: multiple users with email \"{0}\" exist", email);
						throw new Exception(msg);
				}
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
					throw;
				}
			} finally {
				if (session != null) {
					session.Close();
				}
			}
			return answer;
		}

		public int SetProblem(int userId, string problemName) {
			int answer = 0;

			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				P_User user = session.Load<P_User>(userId);

				// If the user has no open Episode, or if the open Episode is for a different problem, we need
				// to generate a new Episode
				if (user.OpenEpisode == null || user.OpenEpisode.Problem.Name != problemName) {
					ICriteria criterion = session.CreateCriteria(typeof(P_Problem));
					criterion.Add(Expression.Eq("Name", problemName));
					P_Problem problem = criterion.UniqueResult<P_Problem>();
				
					P_Episode episode = new P_Episode(problem);
					user.AddEpisode(episode);
					session.Save(problem);
					session.Save(episode);
					answer = problem.Id;
				} else {
					// requested problem is already associate with the user's open episode, do nothing
					answer = user.OpenEpisode.Problem.Id;
				}

				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
					throw;
				}
			} finally {
				if (session != null) {
					session.Close();
				}
			}
			return answer;
		}

		/// <summary>
		/// Save the given state into the user's open episode.
		/// N.B. We're assuming that the user is logged in and has an open episode
		/// </summary>
		/// <param name="user"></param>
		/// <param name="state"></param>
		public void SetState(int userId, P_State state) {
			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				P_User user = session.Load<P_User>(userId);

				user.OpenEpisode.AddState(state);
				session.Save(state);

				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
					throw;
				}
			} finally {
				if (session != null) {
					session.Close();
				}
			}
		}

		public void SetState(int userId, State rawState) {
			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				P_User user = session.Load<P_User>(userId);

				ICriteria criterion = session.CreateCriteria(typeof(P_Cooler));
				criterion.Add(Expression.Eq("Name", rawState.coolerName));
				P_Cooler cooler = criterion.UniqueResult<P_Cooler>();

				criterion = session.CreateCriteria(typeof(P_Material));
				criterion.Add(Expression.Eq("Name", rawState.materialName));
				P_Material material = criterion.UniqueResult<P_Material>();

				P_State state = new P_State(rawState.length, rawState.crossSection, rawState.powerFactor, rawState.inputPower, rawState.cost, rawState.stressLimit, rawState.temperature, rawState.cooledLength, rawState.isValidSolution);
				state.Cooler = cooler;
				state.Material = material;

				user.OpenEpisode.AddState(state);
				session.Save(state);

				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
					throw;
				}
			} finally {
				if (session != null) {
					session.Close();
				}
			}

		}

		public P_User[] ListUsers() {
			IList<P_User> users = null;

			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				ICriteria criterion = session.CreateCriteria(typeof(P_User));
				users = criterion.List<P_User>();
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
					throw;
				}
			} finally {
				if (session != null) {
					session.Close();
				}
			}
			if (users != null) {
				P_User[] answer = new P_User[users.Count];
				users.CopyTo(answer, 0);
				return answer;
			} else {
				return null;
			}
		}

		public P_Episode[] ListEpisodes(P_User user) {
			P_Episode[] answer = null;

			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				//session.Lock(user, LockMode.None);
				session.Update(user);
				answer = new P_Episode[user.Episodes.Count];
				int i = 0;
				foreach (P_Episode e in user.Episodes) {
					session.Update(e);
					answer[i++] = e;
				}
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
					throw;
				}
			} finally {
				if (session != null) {
					session.Close();
				}
			}
			return answer;
		}

		public P_State[] ListStates(P_Episode episode) {
			P_State[] answer = null;

			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				session.Lock(episode, LockMode.None);
				answer = new P_State[episode.States.Count];
				int i = 0;
				foreach (P_State s in episode.States) {
					session.Update(s);
					answer[i++] = s;
				}
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
					throw;
				}
			} finally {
				if (session != null) {
					session.Close();
				}
			}
			return answer;
		}

	}

}
