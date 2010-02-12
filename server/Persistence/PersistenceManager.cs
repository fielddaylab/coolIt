using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool;
using NHibernate.Criterion;
using System.IO;
using CryoLib;
using System.Configuration;

namespace Persistence {
	public class PersistenceManager {
		NHibernate.Cfg.Configuration cfg;
		ISessionFactory factory;
		Random rand = new Random();
		P_Problem[] problemList;
		P_Cooler[] coolerList;
		P_Material[] materialList;
		private string dataDir;
		private string schemaDir;


		public PersistenceManager() {
			dataDir = System.Configuration.ConfigurationManager.AppSettings["DataDir"];
			schemaDir = System.Configuration.ConfigurationManager.AppSettings["SchemaDir"];

			cfg = new NHibernate.Cfg.Configuration();
			cfg.AddAssembly("Persistence");
			factory = cfg.BuildSessionFactory();
			try {
				problemList = ListAllProblems();
				coolerList = ListAllCoolers();
				materialList = ListAllMaterials();
			} catch (Exception ex) {
				problemList = new P_Problem[0];
				coolerList = new P_Cooler[0];
				materialList = new P_Material[0];
			}
		}

		public void InitDatabase() {
			NHibernate.Tool.hbm2ddl.SchemaExport schemaExporter = new NHibernate.Tool.hbm2ddl.SchemaExport(cfg);
			schemaExporter.Create(true, true);
			initProblems();
			initCoolers();
			initMaterials();
			problemList = ListAllProblems();
			coolerList = ListAllCoolers();
			materialList = ListAllMaterials();
		}

		private object chooseRandom(object[] list) {
			int i = rand.Next() % list.Length;
			return list[i];
		}

		public P_State RandomState() {
			P_State answer = P_State.RandomState();
			answer.Cooler = (P_Cooler)chooseRandom(coolerList);
			answer.Material = (P_Material)chooseRandom(materialList);
			return answer;
		}


		public void CreateNewUser(string name, string pwd, string email) {
			P_User newUser = new P_User();
			newUser.UserName = name;
			newUser.Password = pwd;
			newUser.EmailAddr = email;
			newUser.LastLogin = DateTime.Now;

			ISession session = factory.OpenSession();
			ITransaction transaction = session.BeginTransaction();
			session.Save(newUser);
			transaction.Commit();
			session.Close();
		}

		public P_User[] ListAllUsers() {
			ISession session = factory.OpenSession();
			ICriteria criterion = session.CreateCriteria( typeof(P_User) );
			System.Collections.IList userList = criterion.List();
			P_User[] answer = new P_User[ userList.Count ];
			for( int i=0; i<userList.Count; i++ ) {
				answer[i] = (P_User)userList[i];
			}
			return answer;
		}

		public P_User[] ListUsersByEmail(string email) {
			using (ISession session = factory.OpenSession()) {
				ICriteria criterion = session.CreateCriteria( typeof(P_User) );
				criterion.Add(Expression.Eq("EmailAddr", email));
				System.Collections.IList userList = criterion.List();
				P_User[] answer = new P_User[userList.Count];
				for (int i = 0; i < userList.Count; i++) {
					answer[i] = (P_User)userList[i];
				}
				return answer;
			}
		}

		public void PersistUser(P_User user) {
			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();
				session.SaveOrUpdate(user);
				foreach (P_Episode episode in user.Episodes) {
					session.SaveOrUpdate(episode);
				}
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
				}
				throw;
			} finally {
				if (session != null) {
					session.Close();
				}
			}
		}

		public P_Problem[] ListAllProblems() {
			ISession session = factory.OpenSession();
			ICriteria criterion = session.CreateCriteria(typeof(P_Problem));
			System.Collections.IList problemList = criterion.List();
			P_Problem[] answer = new P_Problem[problemList.Count];
			for (int i = 0; i < problemList.Count; i++) {
				answer[i] = (P_Problem)problemList[i];
			}
			return answer;
		}

		public P_Cooler[] ListAllCoolers() {
			ISession session = factory.OpenSession();
			ICriteria criterion = session.CreateCriteria(typeof(P_Cooler));
			System.Collections.IList coolerList = criterion.List();
			P_Cooler[] answer = new P_Cooler[coolerList.Count];
			for (int i = 0; i < coolerList.Count; i++) {
				answer[i] = (P_Cooler)coolerList[i];
			}
			return answer;
		}

		public P_Material[] ListAllMaterials() {
			ISession session = factory.OpenSession();
			ICriteria criterion = session.CreateCriteria(typeof(P_Material));
			System.Collections.IList materialsList = criterion.List();
			P_Material[] answer = new P_Material[materialsList.Count];
			for (int i = 0; i < materialsList.Count; i++) {
				answer[i] = (P_Material)materialsList[i];
			}
			return answer;
		}


		private void initProblems() {
				// Get the list of existing problems from our XML data file
			string problemsDataFile = Path.Combine(dataDir, "Problems.xml");
			string problemsSchemaFile = Path.Combine(schemaDir, "Problems.xsd");
			ProblemCollection problems = new ProblemCollection(problemsDataFile, problemsSchemaFile);

				// Persist the problems in the database
			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();
				foreach (Problem p in problems) {
					P_Problem p_prob = new P_Problem( p.Name );
					p_prob.Name = p.Name;
					session.Save(p_prob);
				}
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
				}
				throw;
			} finally {
				if (session != null) {
					session.Close();
				}
			}
		}

		private void initCoolers() {
				// Get the list of existing coolers from our XML data file
			string coolersDataFile = Path.Combine(dataDir, "Coolers.xml");
			string coolersSchemaFile = Path.Combine(schemaDir, "Coolers.xsd");
			CoolerTypeCollection coolers = new CoolerTypeCollection(coolersDataFile, coolersSchemaFile);

				// Persist the list in the database
			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();
				foreach (CoolerType c in coolers) {
					P_Cooler p_cool = new P_Cooler();
					p_cool.Name = c.Name;
					session.Save(p_cool);
				}
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
				}
				throw;
			} finally {
				if (session != null) {
					session.Close();
				}
			}
		}

		private void initMaterials() {
			// Get the list of existing materials from our XML data file
			string materialsDataFile = Path.Combine(dataDir, "Materials.xml");
			string materialsSchemaFile = Path.Combine(schemaDir, "Materials.xsd");
			MaterialsCollection materials = new MaterialsCollection(materialsDataFile, materialsSchemaFile);

				// Persist the list in the database
			ISession session = null;
			ITransaction transaction = null;
			try {
				session = factory.OpenSession();
				transaction = session.BeginTransaction();
				foreach (Material m in materials) {
					P_Material p_mat = new P_Material();
					p_mat.Name = m.Name;
					session.Save(p_mat);
				}
				transaction.Commit();
			} catch {
				if (transaction != null) {
					transaction.Rollback();
				}
				throw;
			} finally {
				if (session != null) {
					session.Close();
				}
			}
		}

	}
}
