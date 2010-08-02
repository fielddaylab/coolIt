using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Persistence;
using System.Data.SqlClient;
using System.Configuration;

namespace TestDriver {
	public partial class Form1 : Form {

		private PersistenceManager pm;
		private API api;
		private P_User[] users;
		private P_Episode[] episodes;
		private P_State[] states;
		private int curUser;
		private int curProblem;
		private DataGridViewCell cell = new DataGridViewTextBoxCell();

		private static readonly log4net.ILog _logger
					= log4net.LogManager.GetLogger(
							System.Reflection.MethodBase.GetCurrentMethod()
							 .DeclaringType);



		public Form1() {
			InitializeComponent();
			pm = new PersistenceManager();
			string initDb = ConfigurationManager.AppSettings["InitDB"];
			if (initDb == "true") {
				pm.InitDatabase();
			}
			api = new API();
			initProblemsListBox();
			initUsersGridView();
			initEpisodesGridView();
			initStatesGridView();
			updateUsers();
		}

		private void initEpisodesGridView() {
			episodesListGrid.AutoGenerateColumns = false;
			episodesListGrid.Columns.Add(genColumn("Id", "Id", 50));
			episodesListGrid.Columns.Add(genColumn("IsOpen", "Is Open", 75));
			episodesListGrid.Columns.Add(genColumn("UserId", "User Id", 75));
			episodesListGrid.Columns.Add(genColumn("ProblemId", "Problem Id", 75));
		}

		private void initUsersGridView() {
			userListGrid.AutoGenerateColumns = false;
			userListGrid.Columns.Add( genColumn("Id","Id",50) );
			userListGrid.Columns.Add( genColumn("EmailAddr", "Email Addr", 150) );
			userListGrid.Columns.Add(genColumn("LastLogin", "Last Login", 150));
		}

		private void initStatesGridView() {
			statesListGrid.AutoGenerateColumns = false;
			statesListGrid.Columns.Add(genColumn("Id", "Id", 50));
		}

		private DataGridViewColumn genColumn(string propertyName, string header, int width) {
			DataGridViewColumn answer = new DataGridViewColumn(cell);
			answer.DataPropertyName = propertyName;
			answer.Name = header;
			answer.Width = width;
			return answer;
		}

		private void initProblemsListBox() {
			P_Problem[] problemList = pm.ListAllProblems();
			problemsListBox.Items.Clear();
			foreach (P_Problem p in problemList) {
				problemsListBox.Items.Add(p.Name);
			}
			if (problemsListBox.Items.Count > 0) {
				problemsListBox.SelectedIndex = 0;
			}
		}

		private void updateUsers() {
			users = api.ListUsers();
			userListGrid.DataSource = users;
			if (users.Length == 0) {
				updateEpisodes(null);
			} else {
				updateEpisodes(users[0]);
			}
		}

		private void updateEpisodes( P_User user ) {
			if (user == null) {
				episodes = new P_Episode[0];
			} else {
				episodes = api.ListEpisodes(user);
			}
			episodesListGrid.DataSource = episodes;
		}

		private void updateStates(P_Episode episode) {
			if (episode == null) {
				states = new P_State[0];
			} else {
				states = api.ListStates(episode);
			}
			statesListGrid.DataSource = states;
		}

		private void initDbButton_Click(object sender, EventArgs e) {
			pm.InitDatabase();
			initProblemsListBox();
			updateUsers();
		}


		private void newLoginButton_Click(object sender, EventArgs e) {
			string emailAddr = emailTextBox.Text;
			string msg;
			curUser = api.NewLogin(emailAddr);
			if (curUser == 0) {
				msg = string.Format("An account with email address \"{0}\" already exists", emailAddr);
			} else {
				msg = string.Format("Created new account with email address \"{0}\"", emailAddr);
				updateUsers();
			}
			MessageBox.Show(msg);
		}

		private void loginButton_Click(object sender, EventArgs e) {
			string emailAddr = emailTextBox.Text;
			string msg;
			curUser = api.Login(emailAddr);
			updateUsers();
			if (curUser == null) {
				msg = string.Format("No account with email address \"{0}\" exists", emailAddr);
			} else {
				msg = string.Format("User with email address \"{0}\" is logged in", emailAddr);
			}
			MessageBox.Show(msg);
		}

		private void problemButton_Click(object sender, EventArgs e) {
			if( curUser == 0 ) {
				MessageBox.Show( "You must login before you can select a problem" );
				return;
			}
			string problemName = (string)problemsListBox.SelectedItem;
			curProblem = api.SetProblem(curUser, problemName);
			updateUsers();
			MessageBox.Show(string.Format("Problem \"{0}\" has been selected", problemName));
		}

		private void setStateButton_Click(object sender, EventArgs e) {
			if (curUser == 0) {
				MessageBox.Show("You must login before you can set a state");
				return;
			}
			if (curProblem == 0) {
				MessageBox.Show("You must select a problem before you can set a state");
				return;
			}
			P_State state = pm.RandomState();
			api.SetState(curUser, state);
			updateUsers();
			
		}

		private void userListGrid_SelectionChanged(object sender, EventArgs e) {
			if (userListGrid.SelectedRows.Count == 0) {
				updateEpisodes(null);
			} else {
				DataGridViewRow row = userListGrid.SelectedRows[0];
				P_User selectedUser = users[row.Index];
				updateEpisodes(selectedUser);
			}
		}

		private void episodesListGrid_SelectionChanged(object sender, EventArgs e) {
			if (episodesListGrid.SelectedRows.Count == 0) {
				updateStates(null);
			} else {
				DataGridViewRow row = episodesListGrid.SelectedRows[0];
				P_Episode selectedEpisode = episodes[row.Index];
				updateStates(selectedEpisode);
			}

		}
	}
}