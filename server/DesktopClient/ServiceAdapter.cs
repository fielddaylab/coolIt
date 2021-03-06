using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using CryoLib;



namespace DesktopClient {
	public class ServiceAdapter {
		private DesktopClient.CoolIt_Service.CoolIt_Service webService;
		private bool direct = false;
		private Material[] materials;
		private Cooler[] coolers;
		private Problem[] problems;
		private MathGate[] mathGates;
		private string dataDir;
		private string schemaDir;
		private MyAssemblyInfo myVersion;
		private MyAssemblyInfo cryolibVersion;
		private MyAssemblyInfo webServiceVersion;
		private static string imageBaseUrl;

		public MyAssemblyInfo DesktopClientVersion {
			get { return myVersion; }
		}

		public MyAssemblyInfo WebServiceVersion {
			get { return webServiceVersion; }
		}

		public MyAssemblyInfo CryolibVersion {
			get { return cryolibVersion; }
		}

		public string WebServiceURL {
			get { return webService.Url; }
		}

		public static string ImageBaseUrl {
			get { return imageBaseUrl; }
		}

		/// <summary>
		/// Arrange a static method for finding a list of known service providers
		/// </summary>
		private static List<ServiceProvider> providers = new List<ServiceProvider>();
		static ServiceAdapter() {
			//providers.Add(new ServiceProvider("direct", ""));
			providers.Add(new ServiceProvider("debug", "http://localhost:58801/CoolIt_Service.asmx"));
			providers.Add(new ServiceProvider("localhost", "http://localhost/CoolIt_Service/CoolIt_Service.asmx"));
			providers.Add(new ServiceProvider("Production", "http://atswindev.doit.wisc.edu/CoolIt_Service/CoolIt_Service.asmx"));
            providers.Add(new ServiceProvider("Stagomg", "http://atswindev.doit.wisc.edu/CoolIt_Service_Staging/CoolIt_Service.asmx"));
		}
		public static List<ServiceProvider> Providers {
			get { return providers; }
		}

		/// <summary>
		/// Constructor using a ServiceProvider object
		/// </summary>
		/// <param name="p"></param>
		public ServiceAdapter(ServiceProvider p) {

			// We need the web service proxy to support cookies so we can use one to store the Session Id
			// that way the server can use the Session to store session specific data.
			CookieContainer cookieContainer = new CookieContainer();
			webService = new DesktopClient.CoolIt_Service.CoolIt_Service();
			webService.CookieContainer = cookieContainer;

			if (p.Name == "direct" ) {
				NameValueCollection settings = System.Configuration.ConfigurationManager.AppSettings;
				dataDir = settings["DataDir"];
				schemaDir = settings["SchemaDir"];
				direct = true;
			} else {
				webService.Url = p.Url;
			}
			checkVersions();
			coolers = findCoolers();
			materials = findMaterials();
			problems = findProblems();
			mathGates = findMathGates();

			string baseUrl = p.Url.Substring(0, p.Url.LastIndexOf('/'));
			imageBaseUrl = baseUrl + "/Images";
		}

		private static string WEB_SERVICE_MAJOR_VERSION = "2";
		private static string WEB_SERVICE_MINOR_VERSION = "14";
		private void checkVersions() {

				// Check that web service version is as expected
			DesktopClient.CoolIt_Service.MyAssemblyInfo info = webService.WebServiceVersion();
			webServiceVersion = new MyAssemblyInfo(info.Major, info.Minor, info.Build, info.Revision);
			if( webServiceVersion.Major != WEB_SERVICE_MAJOR_VERSION || webServiceVersion.Minor != WEB_SERVICE_MINOR_VERSION ) {
				string msg = string.Format("Unexpected Web Service Version. Expected {0}.{1}, found {2}.{3}",
					WEB_SERVICE_MAJOR_VERSION, WEB_SERVICE_MINOR_VERSION, webServiceVersion.Major, webServiceVersion.Minor);
				throw new Exception(msg);
			}

				// Check that web service is using the same version of Cryolib that we are
			info = webService.CryolibVersion();
			cryolibVersion = new MyAssemblyInfo(info.Major, info.Minor, info.Build, info.Revision);
			MyAssemblyInfo myLibVersion = new MyAssemblyInfo();
			if( cryolibVersion.Major != myLibVersion.Major || cryolibVersion.Minor != myLibVersion.Minor ) {
				string msg = string.Format( "Local and Web Service versions of Cryolib do not match. Local = {0}.{1}, Web service = {2}.{3}",
					myLibVersion.Major, myLibVersion.Minor, cryolibVersion.Major, cryolibVersion.Minor );
				throw new Exception( msg );
			}

			myVersion = new MyAssemblyInfo(System.Reflection.Assembly.GetExecutingAssembly());
		}

		/// <summary>
		/// Get a list of coolers from the serivce provider
		/// </summary>
		/// <returns>The list of coolers</returns>
		public Cooler[] GetCoolers() {
			return coolers;
		}

		public Material[] GetMaterials() {
			return materials;
		}

		public Problem[] GetProblems() {
			return problems;
		}

		public Feedback GetFeedback() {
			CoolIt_Service.Feedback rawFeedback = webService.GetFeedback();
			return new Feedback(rawFeedback.Text, rawFeedback.CutScreen);
		}

		public MathGate[] GetMathGates() {
			return mathGates;
		}

		public bool HasCapability(CAPABILITY desiredCapability) {
			switch (desiredCapability) {
				case CAPABILITY.CP_VS_HEAT_LEAK_GRAPH:
					return webService.HasCapability(DesktopClient.CoolIt_Service.CAPABILITY.CP_VS_HEAT_LEAK_GRAPH);
				default:
					throw new Exception("Unexpected capability requested");
			}
		}

		public bool NewLogin(string emailAddr) {
			return webService.NewLogin(emailAddr);
		}

		public bool Login(string emailAddr) {
			return webService.Login(emailAddr);
		}

		public bool TryMathGate(string name, double[] proposedAnswers) {
			return webService.TryMathGate(name, proposedAnswers);
		}

		public void SetStrut(string materialName, double length, double crossSection) {
			webService.SetStrut(materialName, length, crossSection);
		}

		public State Run() {
			DesktopClient.CoolIt_Service.State rawState = webService.Run();
			if (rawState == null) {
				return null;
			}
			State answer = new State();
			answer.coolerName = rawState.coolerName;
			answer.numStruts = rawState.numStruts;
			answer.crossSection = rawState.crossSection;
			answer.length = rawState.length;
			answer.materialName = rawState.materialName;
			answer.powerFactor = rawState.powerFactor;
			answer.temperature = rawState.temperature;
			answer.cost = rawState.cost;
			answer.inputPower = rawState.inputPower;
			answer.stressLimit = rawState.stressLimit;
			answer.isValidSolution = rawState.isValidSolution;
			answer.problemName = rawState.problemName;
			return answer;
		}


		public void SetCooler(string coolerName, double powerFactor) {
			webService.SetCooler(coolerName, powerFactor);
		}

		public void SetProblem(string problemName) {
			webService.SetProblem(problemName);
		}

		private MathGate[] findMathGates() {
			CoolIt_Service.MathGate[] rawMathGates = webService.GetMathGates();
			MathGate[] answer = new MathGate[rawMathGates.Length];
			for (int i = 0; i < rawMathGates.Length; i++) {
				CoolIt_Service.MathGate rawGate = rawMathGates[i];
				MathGateProblem[] problems = new MathGateProblem[rawGate.Problems.Length];
				for( int j=0; j<rawGate.Problems.Length; j++ ) {
					CoolIt_Service.MathGateProblem rawProblem = rawGate.Problems[j];
					problems[j] = new MathGateProblem( rawProblem.Description, rawProblem.CorrectAnswer, rawProblem.PrecisionRequired );
				}
				CAPABILITY cap;
				switch (rawGate.Capability) {
					case DesktopClient.CoolIt_Service.CAPABILITY.CP_VS_HEAT_LEAK_GRAPH:
						cap = CAPABILITY.CP_VS_HEAT_LEAK_GRAPH;
						break;
					default:
						throw new Exception("Unexpteded capability found");
				}
				answer[i] = new MathGate(rawGate.Name, rawGate.ID, problems, cap );
			}
			return answer;
		}

		/// <summary>
		/// Retrieve the list of problems from the web service and convert them from the "wire format"
		/// to Problem objects.
		/// </summary>
		/// <returns></returns>
		private Problem[] findProblems() {
			DesktopClient.CoolIt_Service.Problem[] rawProblems = webService.GetProblems();
			Problem [] answer = new Problem[rawProblems.Length];
			for (int i = 0; i < rawProblems.Length; i++) {
				answer[i] = convertProblem( rawProblems[i] );
			}
			return answer;
		}

		/// <summary>
		/// Convert a single problem from the format provided by the web service to a Problem object.
		/// </summary>
		/// <param name="rawProblem">Problem in format provided by web service</param>
		/// <returns>Converted Problem object</returns>
		private Problem convertProblem(DesktopClient.CoolIt_Service.Problem rawProblem) {
			Problem answer = new Problem();
			answer.Name = rawProblem.Name;
			answer.Description = rawProblem.Description;
			answer.MonetaryIncentive = rawProblem.MonetaryIncentive;
			answer.HeatLeak = rawProblem.HeatLeak;
			answer.SupportMode = convertSupportMode(rawProblem.SupportMode);
			answer.SupportNumber = rawProblem.SupportNumber;
			Constraint[] constraints = new Constraint[rawProblem.Constraints.Length];
			for (int j = 0; j < rawProblem.Constraints.Length; j++) {
				constraints[j] = convertConstraint(rawProblem.Constraints[j]);
			}
			answer.Constraints = constraints;
			answer.ImageCollection = convertImageCollection(rawProblem.ImageCollection);
			return answer;
		}

		private ProblemImageCollection convertImageCollection(DesktopClient.CoolIt_Service.ProblemImageCollection rawCollection) {
			ProblemImageCollection answer = new ProblemImageCollection();
			answer.BaseURI = rawCollection.BaseURI;
			answer.Intro = rawCollection.Intro;
			answer.Success = rawCollection.Success;
			answer.FailPowerLimit = rawCollection.FailPowerLimit;
			answer.FailStrutBreaks = rawCollection.FailStrutBreaks;
			answer.FailTooHot = rawCollection.FailTooHot;
			answer.PickerImageCollection = convertPickerImageCollection( rawCollection.PickerImageCollection );
			return answer;
		}

		private PickerImageCollection convertPickerImageCollection(DesktopClient.CoolIt_Service.PickerImageCollection rawCollection) {
			PickerImageCollection answer = new PickerImageCollection();
			answer.BaseName = rawCollection.BaseName;
			answer.Length = rawCollection.Length;
			answer.Width = rawCollection.Width;
			return answer;
		}

		/// <summary>
		/// Convert a Support Mode from the format provided by the web service to the format
		/// needed in a Problem object.
		/// </summary>
		/// <param name="rawMode">Support mode as encoded by web service</param>
		/// <returns>Support mode as encoded within a Problem object</returns>
		private SupportMode convertSupportMode(DesktopClient.CoolIt_Service.SupportMode rawMode) {
			switch( rawMode ) {
				case DesktopClient.CoolIt_Service.SupportMode.COMPRESSION:
					return SupportMode.COMPRESSION;
				case DesktopClient.CoolIt_Service.SupportMode.TENSION:
					return SupportMode.TENSION;
				default:
					throw new Exception("Unexpected support mode");
			}
		}

		/// <summary>
		/// Convert a constraint from the format provided by the web service to the format
		/// needed in a Problem object.
		/// </summary>
		/// <param name="rawConstraint">Constraint as encoded by the web service</param>
		/// <returns>Constraint encoded in format needed in Problem object</returns>
		private Constraint convertConstraint(DesktopClient.CoolIt_Service.Constraint rawConstraint) {
			VALUE value;
			switch (rawConstraint.Value) {
				case DesktopClient.CoolIt_Service.VALUE.COST:
					value = VALUE.COST;
					break;
				case DesktopClient.CoolIt_Service.VALUE.FORCE_LIMIT:
					value = VALUE.FORCE_LIMIT;
					break;
				case DesktopClient.CoolIt_Service.VALUE.INPUT_POWER:
					value = VALUE.INPUT_POWER;
					break;
				case DesktopClient.CoolIt_Service.VALUE.TEMP:
					value = VALUE.TEMP;
					break;
				case DesktopClient.CoolIt_Service.VALUE.STRUT_CROSS_SECTION:
					value = VALUE.STRUT_CROSS_SECTION;
					break;
				case DesktopClient.CoolIt_Service.VALUE.STRUT_LENGTH:
					value = VALUE.STRUT_LENGTH;
					break;
                case DesktopClient.CoolIt_Service.VALUE.DISPLACEMENT:
                    value = VALUE.DISPLACEMENT;
                    break;
				default:
					string msg = String.Format("Unexpected constraint value ({0})", rawConstraint.Value);
					throw new Exception(msg);
			}

			OP op = OP.EQ;
			switch (rawConstraint.Op) {
				case DesktopClient.CoolIt_Service.OP.EQ:
					op = OP.EQ;
					break;
				case DesktopClient.CoolIt_Service.OP.GE:
					op = OP.GE;
					break;
				case DesktopClient.CoolIt_Service.OP.GT:
					op = OP.GT;
					break;
				case DesktopClient.CoolIt_Service.OP.LE:
					op = OP.LE;
					break;
				case DesktopClient.CoolIt_Service.OP.LT:
					op = OP.LT;
					break;
				case DesktopClient.CoolIt_Service.OP.NE:
					op = OP.NE;
					break;
			}
			return new Constraint(value, op, rawConstraint.Target);
		}

		private Cooler[] findCoolers() {
			Cooler[] answer;
			if (direct) {
				string coolerFile = Path.Combine(dataDir, "Coolers.xml");
				string coolerSchema = Path.Combine(schemaDir, "Coolers.xsd");
				CoolerCollection coolers = new CoolerCollection(coolerFile, coolerSchema);
				answer = new Cooler[coolers.Count];
				for (int i = 0; i < coolers.Count; i++) {
					answer[i] = (Cooler)coolers[i];
				}
			} else {
				DesktopClient.CoolIt_Service.Cooler[] rawCoolers = webService.GetCoolers();
				answer = new Cooler[rawCoolers.Length];
				InputPowerCalculator calc = getInputPowerCalc();
				for (int i = 0; i < rawCoolers.Length; i++) {
					DesktopClient.CoolIt_Service.Cooler raw = rawCoolers[i];
					List<DataPoint> data = new List<DataPoint>();
					for (int j = 0; j < raw.CPM.Length; j++) {
						DesktopClient.CoolIt_Service.DataPoint rawPoint = raw.CPM[j];
						DataPoint point = new DataPoint(rawPoint.temp, rawPoint.data);
						data.Add(point);
					}
					answer[i] = new Cooler(raw.Name, raw.id, data, raw.price, raw.priceUnit, raw.currencyUnit);
					answer[i].InputPowerCalculator = calc;
				}
			}
			return answer;
		}

		private InputPowerCalculator getInputPowerCalc() {
			DesktopClient.CoolIt_Service.DataPoint[] specificPowerData = webService.GetSpecificPowerData();
			DataPoint[] data = new DataPoint[specificPowerData.Length];
			for (int i = 0; i < specificPowerData.Length; i++) {
				data[i] = new DataPoint(specificPowerData[i].temp, specificPowerData[i].data);
			}
			InputPowerCalculator calc = new InputPowerCalculator(data);
			return calc;
		}

		/// <summary>
		/// Get a list of coolers from the serivce provider
		/// </summary>
		/// <returns>The list of coolers</returns>
		private Material[] findMaterials() {
			Material[] answer;
			if (direct) {
				string materialsFile = Path.Combine(dataDir, "Materials.xml");
				string materialsSchema = Path.Combine(schemaDir, "Materials.xsd");
				MaterialsCollection materials = new MaterialsCollection(materialsFile, materialsSchema);
				answer = new Material[materials.Count];
				for (int i = 0; i < materials.Count; i++) {
					answer[i] = (Material)materials[i];
				}
			} else {
				DesktopClient.CoolIt_Service.Material[] rawMaterials = webService.GetMaterials();
				answer = new Material[rawMaterials.Length];
				for (int i = 0; i < rawMaterials.Length; i++) {
					DesktopClient.CoolIt_Service.Material raw = rawMaterials[i];
					List<DataPoint> data = new List<DataPoint>();
					for (int j = 0; j < raw.MP.Length; j++) {
						DesktopClient.CoolIt_Service.DataPoint rawPoint = raw.MP[j];
						DataPoint point = new DataPoint(rawPoint.temp, rawPoint.data);
						data.Add(point);
					}
					if (raw.IntegratedThermalConductivity == null) {
						answer[i] = new Material(raw.Name, raw.id, raw.yieldStrength, data, null, raw.price, raw.priceUnit, raw.currencyUnit);
					} else {
						List<DataPoint> integratedThermalConductivity = new List<DataPoint>();
						for (int j = 0; j < raw.IntegratedThermalConductivity.Length; j++) {
							DesktopClient.CoolIt_Service.DataPoint rawPoint = raw.IntegratedThermalConductivity[j];
							DataPoint point = new DataPoint(rawPoint.temp, rawPoint.data);
							integratedThermalConductivity.Add(point);
						}
						answer[i] = new Material(raw.Name, raw.id, raw.yieldStrength, data, integratedThermalConductivity, raw.price, raw.priceUnit, raw.currencyUnit);
					}
				
				}
			}
			return answer;
		}

		private Material findMaterial(string materialName) {
			Material material = null;
			for (int i = 0; i < materials.Length; i++) {
				if (materials[i].Name == materialName) {
					material = materials[i];
				}
			}
			if (material == null) {
				string msg = string.Format("Can't find material \"{0}\"", materialName);
				throw new ArgumentException(msg);
			}
			return material;
		}

		private Cooler findCooler(string coolerName) {
			Cooler cooler = null;
			for (int i = 0; i < coolers.Length; i++) {
				if (coolers[i].Name == coolerName) {
					cooler = coolers[i];
				}
			}
			if (cooler == null) {
				string msg = string.Format("Can't find cooler \"{0}\"", coolerName);
				throw new ArgumentException(msg);
			}
			return cooler;

		}

		//public double Simulate( double length, double crossSectionalArea, string materialName, string coolerName ) {
		//    if (direct) {
		//        Cooler cooler = findCooler(coolerName);
		//        Material material = findMaterial(materialName);
		//        SteadyStateSimulator ss = new SteadyStateSimulator();
		//        return ss.simulate(length, crossSectionalArea, material, cooler );
		//    } else {
		//        return webService.Simulate(length, crossSectionalArea, materialName, coolerName);
		//    }
		//}

		//public double SimulatePF(double length, double crossSectionalArea, string materialName, string coolerName, double powerFactor) {
		//    if (direct) {
		//        Material material = findMaterial(materialName);
		//        Cooler cooler = findCooler(coolerName);
		//        SteadyStateSimulator ss = new SteadyStateSimulator();
		//        return ss.simulate(length, crossSectionalArea, material, cooler, powerFactor);
		//    } else {
		//        return webService.SimulatePF(length, crossSectionalArea, materialName, coolerName, powerFactor);
		//    }
		//}
	}

	/// <summary>
	/// Description of a Service provider.
	/// These consist of a user-friendly name and a url where the
	/// provider can be contacted.
	/// </summary>
	public class ServiceProvider {
		private string name;
		private string url;

		public string Name {
			get { return name; }
		}

		public string Url {
			get { return url; }
		}

		public ServiceProvider(string name, string url) {
			this.name = name;
			this.url = url;
		}

		public override string ToString() {
			return string.Format("{0,-15} {1}", name, url);
		}
	}
}
