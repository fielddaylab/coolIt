using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Hosting;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using CryoLib;
using Persistence;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

using log4net;

namespace CoolIt_Service {
	/// <summary>
	/// Summary description for Service1
	/// </summary>
	[WebService(Namespace = "http://www.wisc.edu/doit/ls/coolit/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class CoolIt_Service : System.Web.Services.WebService {

		// These objects can be shared across sessions
		private static CoolerModelCollection coolers;
		private static MaterialsCollection materials;
		private static ProblemCollection problems;
		private static MathGateCollection mathGates;
		private static SpecificPowerDataManager specificPowerData;
		private static SteadyStateSimulator sim;
		private static InputPowerCalculator inputPowerCalc;
		private static SolutionChecker solutionChecker;
		private static Optimizer optimizer;
		private static API api;

        private static readonly log4net.ILog _logger
            = log4net.LogManager.GetLogger(
                    System.Reflection.MethodBase.GetCurrentMethod()
                     .DeclaringType);

		/// <summary>
		/// Constructor
		/// </summary>
		public CoolIt_Service() {
            log4net.Config.XmlConfigurator.Configure();

            _logger.Debug("Spinning up web service");

			if (sim == null) {
				init();
			}
		}

		/// <summary>
		/// Read the data files and set up the MATLAB component.
		/// Would like to do this in a static constructor, but we don't have access to a
		/// HttpRequest object at that time, so it's not clear how to map the paths.
		/// </summary>
		private void init() {
			HttpRequest request = this.Context.Request;
			string dataDir = request.MapPath("Data");
			string schemaDir = request.MapPath("Schema");

            _logger.Debug("Loading SpecificPower.xml");
			string specificPowerDataFile = Path.Combine(dataDir, "SpecificPower.xml");
			string specificPowerSchemaFile = Path.Combine(schemaDir, "SpecificPower.xsd");
			specificPowerData = new SpecificPowerDataManager(specificPowerDataFile, specificPowerSchemaFile);

			inputPowerCalc = new InputPowerCalculator(specificPowerData.Data);

            _logger.Debug("Loading Coolers.xml");
			string coolerDataFile = Path.Combine(dataDir, "Coolers.xml");
			string coolerSchemaFile = Path.Combine(schemaDir, "Coolers.xsd");
			coolers = new CoolerModelCollection(coolerDataFile, coolerSchemaFile );
			foreach (CoolerModel c in coolers) {
				c.InputPowerCalculator = inputPowerCalc;
			}
            _logger.DebugFormat("{0} coolers loaded", coolers.Count);

            _logger.Debug("Loading Materials.xml");
			string materialsDataFile = Path.Combine(dataDir, "Materials.xml");
			string materialsSchemaFile = Path.Combine(schemaDir, "Materials.xsd");
			materials = new MaterialsCollection(materialsDataFile, materialsSchemaFile);
            _logger.DebugFormat("{0} materials loaded", materials.Count);

            _logger.Debug("Loading Problems.xml");
			string problemsDataFile = Path.Combine(dataDir, "Problems.xml");
			string problemsSchemaFile = Path.Combine(schemaDir, "Problems.xsd");
			problems = new ProblemCollection(problemsDataFile, problemsSchemaFile);
            _logger.DebugFormat("{0} problems loaded", problems.Count);

            _logger.Debug("Loading MathGates.xml");
			string mathGateDataFile = Path.Combine(dataDir, "MathGates.xml");
			string mathGateSchemaFile = Path.Combine(schemaDir, "MathGates.xsd");
			mathGates = new MathGateCollection(mathGateDataFile, mathGateSchemaFile);
            _logger.DebugFormat("{0} math gates loaded", mathGates.Count);

            _logger.Debug("Initializing Optimizer");
            optimizer = new Optimizer(coolers, materials);
            _logger.Debug("Initializaing SolutionChecker");
            solutionChecker = new SolutionChecker(problems);

            _logger.Debug("Initializaing SteadyStateSimulator");
			sim = new SteadyStateSimulator();
            _logger.Debug("Initializing API");
			api = new API();
		}

		/// <summary>
		/// Create a new account for the use with the given email address.
		/// Note: successful completion has the effect of logging in the user.  There is no need
		/// to subesquently call Login().
		/// </summary>
		/// <param name="emailAddr">The email address to associate with the account.</param>
		/// <returns>True if the account could be created and false otherwise.</returns>
		[WebMethod(EnableSession = true)]
		public bool NewLogin(string emailAddr) {
			return newLogin(emailAddr);
		}

		/// <summary>
		/// Login the user who is associated with the given email address.
		/// </summary>
		/// <param name="emailAddr">The email address whose associated user we wish to log in</param>
		/// <returns>True if the user can be logged in and false otherwise.</returns>
		[WebMethod(EnableSession = true)]
		public bool Login(string emailAddr) {
			return login(emailAddr);
		}


		[WebMethod(EnableSession=true)]
		public bool HasCapability( CAPABILITY requestedCapability ) {
			CapabilityManager capMgr = getCapabilityManager();
			return capMgr.HasCapability(requestedCapability);
		}

		[WebMethod(EnableSession=true)]
		public bool TryMathGate(string gateName, double [] answers ) {
			CapabilityManager capMgr = getCapabilityManager();
			return capMgr.TryMathGate(gateName, answers);
		}

		[WebMethod]
		public MyAssemblyInfo WebServiceVersion() {
			return new MyAssemblyInfo(Assembly.GetExecutingAssembly());
		}

		[WebMethod]
		public MyAssemblyInfo CryolibVersion() {
            _logger.Debug("In CryolibVersion");
			return new MyAssemblyInfo();
		}

		[WebMethod]
		public CoolerModel[] GetCoolerModels() {
			CoolerModel[] answer = new CoolerModel[coolers.Count];
			for (int i = 0; i < coolers.Count; i++) {
				answer[i] = (CoolerModel)coolers[i];
			}
			return answer;
		}

        [WebMethod]
        public CoolerModel GetCoolerModel(int id)
        {
            CoolerModel cool = (CoolerModel)coolers.Find(id);
            cool.ShowObjectDetails = true;
            return cool;
        }

		[WebMethod]
		public Material[] GetMaterials() {
			Material[] answer = new Material[materials.Count];
			for (int i = 0; i < materials.Count; i++) {
				answer[i] = (Material)materials[i];
                answer[i].ShowObjectDetails = false;
			}
			return answer;
		}

        [WebMethod]
        public Material GetMaterial(int id)
        {
            Material mat = (Material)materials.Find(id);
            mat.ShowObjectDetails = true;
            return mat;
        }

        [WebMethod]
        public Problem GetProblemByName(string problemName)
        {
            Problem prob = problems[problemName];
            prob.ShowObjectDetails = true;
            return prob;
        }

        [WebMethod]
        public Problem GetProblem(int id)
        {
            Problem prob = (Problem) problems.Find(id);
            prob.ShowObjectDetails = true;
            return prob;
        }

		[WebMethod]
		public Problem[] GetProblems() {
			Problem[] answer = new Problem[problems.Count];
			for (int i = 0; i < problems.Count; i++) {
				answer[i] = (Problem)problems[i];
			}
			return answer;
		}

		[WebMethod]
		public MathGate[] GetMathGates() {
			MathGate[] answer = new MathGate[mathGates.Count];
			for (int i = 0; i < mathGates.Count; i++) {
				answer[i] = (MathGate)mathGates[i];
			}
			return answer;
		}

		[WebMethod]
		public DataPoint[] GetSpecificPowerData() {
			return specificPowerData.Data;
		}

		[WebMethod(EnableSession=true)]
		public void SetStrut(string materialName, double length, double crossSection) {
            //TODO:  Update this to take a strut ID and update the appropriate one in the collection
			setStrut(getState(), "1", materialName, length, crossSection);
		}

		private void setStrut(Problem state, string strutID, string materialName, double length, double crossSection) {
            StrutType strut = state.Struts[strutID];

            strut.Material = (Material)materials[materialName];
            strut.Length = length;
            strut.CrossSectionalArea = crossSection;
		}

		[WebMethod(EnableSession=true)]
		public void SetCooler(string name, double powerFactor) {
            //TODO:  Update this to take a cooler ID and update the appropriate one in the collection
			setCooler(getState(), "1", name, powerFactor);
		}

		private void setCooler(Problem state, string coolerID, string name, double powerFactor) {
            state.Coolers[coolerID].SelectedCooler = (CoolerModel) coolers[name] ;
			state.PowerFactor = powerFactor;
		}
			

		[WebMethod(EnableSession=true)]
		public void SetProblem(string name) {
			setProblem(getState(), name);
		}

		private bool setProblem(Problem state, string name) {
			if (!requireLogin()) {
				// Should not happen as we have anonymous session logins in place
				throw new Exception("Should never happen");
				//return false;
			}

            //Load the problem, do not set state variables
            Problem p = problems[name];
            state.Name = p.Name;
            state.ID = p.ID;
            state.Description = p.Description;
            state.MonetaryIncentive = p.MonetaryIncentive;
            state.HeatLeak = p.HeatLeak;
            state.Constraints = p.Constraints;
            state.Struts = p.Struts;
            state.Coolers = p.Coolers;

            //Create an episode if one is not already creaed, and set foreign key to selected problem
            api.SetProblem((int)Session["userId"], name);

            //Set the state variables to defaults
            initState(state);

            //Save problem, strut and cooler state to the database
			persistState(state);
			return true;
		}

		[WebMethod(EnableSession = true)]
		public Solution[] GetOptimalSolutions() {
			Solution[] solutions = new Solution[problems.Count];
			for (int i = 0; i < problems.Count; i++) {
				Problem p = problems[i];
				solutions[i] = optimizer.OptimalSoultion(problems[i]);
				sanityCheckOptimalSolution(solutions[i]);
			}
			return solutions;
		}

		[WebMethod]
		public string TestDbAccess() {
			string connectionString = ConfigurationManager.ConnectionStrings["System.Data.SqlClient"].ConnectionString;
			SqlConnection conn = new SqlConnection( connectionString );
			SqlCommand cmd = new SqlCommand("Select * from Users", conn);
			SqlDataReader reader = null;
			StringBuilder sb = new StringBuilder();
			try {
				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read()) {
					int id = (int)reader[0];
					string email = (string)reader[1];
					sb.AppendFormat("{0} email = \"{1}\"\r\n", id, email);
				}
			} catch( Exception ex ) {
				return ex.ToString();
			} finally {
				if (reader != null) {
					reader.Close();
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// Check to see that the so-called optimal solution is at least valid
		/// </summary>The proposed optimal solution to be checked</param>
		private void sanityCheckOptimalSolution(Solution solution) {
			Problem state = new Problem();
			setProblem(state, solution.ProblemName);
            //TODO:  remove hardcoded ID
			setCooler(state, solution.CoolerName, "1", solution.CoolerPowerFactor);
            //TODO:  remove hardcoded ID
			setStrut(state, "1", solution.MaterialName, solution.StrutLength, solution.StrutCrossSection);
			run(state);
			if( !state.Solved ) {
				throw new Exception("Calculated optimal solution is not valid");
			}
		}


		[WebMethod(EnableSession = true)]
		public Problem Run() {
			return run( getState() );
		}

		private bool requireLogin() {
			// We'd like to require a login, but the current Flash client does not handle
			// that function.  As a work-around we generate an anonymous account for each
			// browser session.  This code should be forward-compatible, that is if we already
			// have a login at this point, we just go ahead and use that.
			if (Session == null || Session["userId"] == null || (int)Session["userId"] < 1) {
				string fakeEmail = string.Format("Anonymous <{0}>", Session.SessionID);
				newLogin(fakeEmail);
			}

			return true;
		}

		private Problem run( Problem state ) {
			if (!requireLogin()) {
				// Should not happen as we have anonymous session login's in place
				throw new Exception("This should never happen");
				//return null;
			}

            //TODO:  Handle multiple coolers
            CoolerModel cooler = state.Coolers[0].SelectedCooler;
            //Set cooler to the first one in the list by default if no cooler is set
            if (cooler == null) cooler = (CoolerModel) coolers[0];
            cooler.InputPowerCalculator = inputPowerCalc;

            //Set material to the default if no material is set
            //TODO:  Handle multiple struts
            if (state.Struts[0].Material == null) state.Struts[0].Material = (CryoLib.Material) materials[0];
	
            //TODO:  Change to handle multiple struts
            //TODO:  how do you handle the number of struts once they might be different?
			double combinedCrossSection = state.Struts[0].Count * state.Struts[0].CrossSectionalArea;
			state.Cost = cooler.price +  state.Struts[0].Length * combinedCrossSection * state.Struts[0].Material.price;
			state.StressLimit = state.Struts[0].Material.YieldStrength * combinedCrossSection;

			// If temperature goes below known range for the given material the MATLAB code will generate an
			// ApplicationException.  In that case we set temperature and inputPower to impossible values.  UI
			// code can detect this and generate an appropriate message for the user.
			try {
                //TODO:  Change to handle multiple struts
				state.Temperature = sim.simulate(state.Struts[0].Length, combinedCrossSection, state.Struts[0].Material, cooler, state.PowerFactor);
                //TODO:  Change to handle multiple coolers
                state.Coolers[0].InputPower = cooler.InputPower(state.Temperature, state.PowerFactor);
			} catch (ArgumentException ae) {
                _logger.DebugFormat("MATLAB has thrown an exception {0} with temp {1} and power factor {2}", ae.Message, state.Temperature, state.PowerFactor);

                state.Temperature = -1;
                state.Coolers[0].InputPower = -1;
			}

			if (state.Name != null) {
				state.Solved = solutionChecker.CheckSolution(state);
				persistState(state);
			} else {
				state.Solved = false;
			}
			return state;
		}

		private void persistState(Problem state) {
            //TODO:  Should there be better error logging, or just not persist anything?
			if (state.Coolers.Count == 0 || state.Coolers[0].SelectedCooler == null || state.Struts.Count == 0 || state.Struts[0].Material == null ) {
				return;
			}

			api.SetState((int)Session["userId"], state);
		}

		[WebMethod(EnableSession = true)]
		public Feedback GetFeedback() {
			Problem state = getState();
			Solution optSolution = findOptimalSolution(state);
			Feedback answer = solutionChecker.GetFeedback(state,optSolution);
			return answer;
		}

		private Solution findOptimalSolution(Problem state) {
			Optimizer opt = new Optimizer(coolers, materials);
			return opt.OptimalSoultion(state);
		}

		/// <summary>
		/// This method only exists for the purpose of testing whether saving of Session state
		/// is working.  Not needed in production use.
		/// </summary>
		/// <returns></returns>
		//[WebMethod(EnableSession = true)]
		//public int Counter() {
		//    if (Session.IsNewSession || Session["Counter"] == null) {
		//        Session["Counter"] = 0;
		//    }
		//    int answer = (int)Session["Counter"];
		//    Session["Counter"] = answer + 1;
		//    return answer;
		//}



		/// <summary>
		/// Get the CapabilityManager stored in the Session
		/// 
		/// N.B. Web Methods which call this MUST have Session enabled.
		/// </summary>
		/// <returns></returns>
		private CapabilityManager getCapabilityManager() {
			CapabilityManager manager;
			if (Session.IsNewSession || Session["CapabilityManager"] == null) {
				manager = new CapabilityManager( mathGates );
				Session["CapabilityManager"] = manager;
			}
			manager = (CapabilityManager)Session["CapabilityManager"];
			return manager;
		}

		/// <summary>
		/// Create a new account and set the user id into the Session
		/// 
		/// N.B. Web Methods which call this method MUST have Session enabled.
		/// </summary>
		/// <param name="email">The email address to associate with the new account</param>
		/// <returns>True if the account could be created and false otherwise.</returns>
		private bool newLogin( string email ) {
			int userId = api.NewLogin(email);
			if (userId == 0) {
				return false;
			} else {
				Session["userId"] = userId;
				return true;
			}
		}

		/// <summary>
		/// Log in to an existing account and set the user id into the Session
		/// 
		/// N.B. Web Methods which call this method MUST have Session enabled.
		/// </summary>
		/// <param name="email">The email address associated with the user who wants to log in</param>
		/// <returns>True if the user could be logged in and false otherwise.</returns>
		private bool login(string email) {
			int userId = api.Login(email);
			if (userId == 0) {
				return false;
			} else {
				Session["userId"] = userId;
				return true;
			}
		}


		/// <summary>
		/// Get the State object stored in the Session.
		/// 
		/// N.B. Web Methods which call this method MUST have Session enabled.
		/// </summary>
		/// <returns></returns>
		private Problem getState() {
			if (Session.IsNewSession || Session["State"] == null) {
				initState();
			}
			Problem state = (Problem)Session["State"];
			return state;
		}

		private void initState() {
			Problem state = new Problem();
            initState(state);
		}

        /**
         * Set defaults of the state variables into session
         **/
        private void initState(Problem state)
        {
            state.PowerFactor = 1.0;

            //If no cooler are set, add one by default
            if (state.Coolers.Count == 0)
            {
                Cooler defaultCooler = new Cooler();
                defaultCooler.SelectedCooler = (CoolerModel)coolers[0];
                defaultCooler.ID = "1";
                defaultCooler.InputPower = 0;
                state.Coolers.Add(defaultCooler);
            }
            //otherwise set default values for each cooler loaded by the problem
            else
            {
                foreach (Cooler cool in state.Coolers)
                {
                    cool.SelectedCooler = (CoolerModel)coolers[0];
                    cool.InputPower = 0;
                }
            }

            //If no struts are set, add one by default
            if (state.Struts.Count == 0)
            {
                StrutType defaultStrut = new StrutType(0.1, 0.001, ((Material)materials[0]));
                defaultStrut.ID = "1";
                defaultStrut.Count = 1;
                state.Struts.Add(defaultStrut);
            }
            //otherwise set default values for each strut loaded by the problem
            else
            {
                foreach (StrutType strut in state.Struts)
                {
                    strut.Length = 0.1;
                    strut.CrossSectionalArea = 0.001;
                    strut.Material = (CryoLib.Material) materials[0];
                }
            }

            Session["State"] = state;
        }
	}
}
