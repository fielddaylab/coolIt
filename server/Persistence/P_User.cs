using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Collection.Generic;
using NHibernate.Collection;
using Iesi.Collections;

namespace Persistence {
	public class P_User {
		private int id;
		private string userName;
		private string password;
		private string emailAddr;
		private DateTime lastLogin;
		private ISet episodes = new HashedSet();
		private P_Episode openEpisode;

		public P_User() { }

		public P_User(string name, string password, string emailAddr) {
			this.userName = name;
			this.password = password;
			this.emailAddr = emailAddr;
			this.lastLogin = DateTime.Now;
		}

		public P_User(string emailAddr) {
			this.emailAddr = emailAddr;
			this.lastLogin = DateTime.Now;
			this.openEpisode = null;
		}


		public virtual int Id {
			get { return id; }
			set { id = value; }
		}

		public virtual ISet Episodes {
			get { return episodes; }
			set { episodes = value; }
		}

		public virtual P_Episode OpenEpisode {
			get { return openEpisode; }
			set { openEpisode = value; }
		}

		public virtual string UserName {
			get { return userName; }
			set { userName = value; }
		}

		public virtual string Password {
			get { return password; }
			set { password = value; }
		}

		public virtual string EmailAddr {
			get { return emailAddr; }
			set { emailAddr = value; }
		}

		public virtual DateTime LastLogin {
			get { return lastLogin; }
			set { lastLogin = value; }
		}

		public virtual void AddEpisode(P_Episode episode) {
			episode.User = this;
			if (episodes == null) {
				episodes = new HashedSet();
			}
			episodes.Add(episode);
			if (openEpisode != null) {
				openEpisode.Close();
			}
			openEpisode = episode;
		}



	}
}
