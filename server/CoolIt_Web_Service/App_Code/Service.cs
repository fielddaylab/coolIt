using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using CryoLib;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;

[WebService(Namespace = "http://www.engr.wisc.edu/cryo")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{

	[WebMethod]
	public string [] AYT() {
		List<string> answer = new List<string>();

		string principal = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
		answer.Add( string.Format("Security Principal is \"{0}\"",principal) );

		answer.AddRange(getPathElements());
		//answer.AddRange(getPathElements(EnvironmentVariableTarget.Machine));
		//answer.AddRange(getPathElements(EnvironmentVariableTarget.Process));
		//answer.AddRange(getPathElements(EnvironmentVariableTarget.User));
		return answer.ToArray();
	}

	private List<string> getPathElements(EnvironmentVariableTarget target) {
		List<string> answer = new List<string>();
		answer.Add("");
		answer.Add(target.ToString());
		IDictionary dict;
		dict = Environment.GetEnvironmentVariables(target);
		string path = (string)dict["Path"];
		if (path == null) {
			answer.Add("(Empty)");
			return answer;
		}
		string[] pathElements = path.Split(new char[] { ';' });
		foreach (string elem in pathElements) {
			answer.Add(elem);
		}
		return answer;
	}

	private List<string> getPathElements() {
		List<string> answer = new List<string>();
		answer.Add("");
		answer.Add("(default)");
		IDictionary dict;
		dict = Environment.GetEnvironmentVariables();
		string path = (string)dict["Path"];
		if (path == null) {
			answer.Add("(Empty)");
			return answer;
		}
		string[] pathElements = path.Split(new char[] { ';' });
		foreach (string elem in pathElements) {
			answer.Add(elem);
		}
		return answer;
	}


	[WebMethod]
	public Cooler[] GetCoolers() {
		CoolerCollection coolers = findCoolers();

		Cooler[] answer = new Cooler[ coolers.Count ];
		for (int i = 0; i < coolers.Count; i++) {
			answer[i] = (Cooler)coolers[i];
		}
		return answer;
	}

	private CoolerCollection findCoolers() {
		string dataDir = ConfigurationManager.AppSettings["DataDir"];
		string schemaDir = ConfigurationManager.AppSettings["SchemaDir"];
		string coolerFile = Path.Combine(dataDir, "Coolers.xml");
		string coolerSchema = Path.Combine(schemaDir, "Coolers.xsd");
		return new CoolerCollection(coolerFile, coolerSchema);
	}

	[WebMethod]
	public Material[] GetMaterials() {
		MaterialsCollection materials = findMaterials();

		Material[] answer = new Material[materials.Count];
		for (int i = 0; i < materials.Count; i++) {
			answer[i] = (Material)materials[i];
		}
		return answer;
	}

	private MaterialsCollection findMaterials() {
		string dataDir = ConfigurationManager.AppSettings["DataDir"];
		string schemaDir = ConfigurationManager.AppSettings["SchemaDir"];
		string materialFile = Path.Combine(dataDir, "Materials.xml");
		string materialSchema = Path.Combine(schemaDir, "Materials.xsd");
		return new MaterialsCollection(materialFile, materialSchema);
	}

	[WebMethod]
	public double Simulate(double length, double crossSection, string materialName, string coolerName) {
		try {
			CoolerCollection coolers = findCoolers();
			Cooler cooler = (Cooler)coolers[coolerName];
			MaterialsCollection materials = findMaterials();
			Material material = (Material)materials[materialName];
			SteadyStateSimulator ssSim = new SteadyStateSimulator();
			return ssSim.simulate(length, crossSection, material, cooler);
		} catch (Exception ex) {
			throw new SoapException(ex.ToString(), new System.Xml.XmlQualifiedName(""));
		}
	}

	[WebMethod]
	public double SimulatePF(double length, double crossSection, string materialName, string coolerName, double powerFactor) {
		try {
			CoolerCollection coolers = findCoolers();
			Cooler cooler = (Cooler)coolers[coolerName];
			MaterialsCollection materials = findMaterials();
			Material material = (Material)materials[materialName];
			SteadyStateSimulator ssSim = new SteadyStateSimulator();
			return ssSim.simulate(length, crossSection, material, cooler, powerFactor);
		} catch (Exception ex) {
			throw new SoapException(ex.ToString(), new System.Xml.XmlQualifiedName(""));
		}
	}


}
