using System;
using System.Collections.Generic;
using System.Text;
using Iesi.Collections;

namespace Persistence {
	public class P_Episode {
		private int id;
		private P_User user;
		private ISet states = new HashedSet();
		private P_Problem problem;
		private bool isOpen;

		public virtual P_Problem Problem {
			get { return problem; }
			set { problem = value; }
		}

		public virtual bool IsOpen {
			get { return isOpen; }
			set { isOpen = value; }
		}

		public virtual ISet States {
			get { return states; }
			set { states = value; }
		}

		public virtual int Id {
			get { return id; }
			set { id = value; }
		}

		public virtual P_User User {
			get { return user; }
			set { user = value; }
		}

		public virtual void AddState(P_ProblemState state) {
			if (!isOpen) {
				throw new Exception("Attempt to add new state to a closed Episode");
			}
			state.Episode = this;
			states.Add(state);
		}

		public virtual void Close() {
			isOpen = false;
		}

		public P_Episode(P_Problem problem) {
			this.problem = problem;
			this.isOpen = true;
		}

		public virtual int UserId {
			get { return user.Id; }
		}

		public virtual int ProblemId {
			get { return problem.Id; }
		}

		protected P_Episode() {
		}


	}
}
