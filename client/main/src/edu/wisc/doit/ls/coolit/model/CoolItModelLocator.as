package edu.wisc.doit.ls.coolit.model {
	import com.adobe.cairngorm.model.ModelLocator;
	
	import edu.wisc.doit.ls.coolit.*;
	import edu.wisc.doit.ls.coolit.model.*;
	
	import mx.collections.ArrayCollection;
	
	[Bindable]
	public class CoolItModelLocator implements ModelLocator {
		private static var modelLocator:CoolItModelLocator;
		
		public var bankBalance:Number = 1500;
		public var temperature:Number;
		public var inputPower:Number;
		public var cost:Number;
		public var stressLimit:Number;
		public var isValidSolution:Boolean;
		
		public var jobModel:JobModel;
		public var coolerModel:CoolerModel;
		public var materialModel:MaterialModel;
		public var stateModel:StateModel;
		public var cryoLibModel:CryoLibModel;
		
		public var servicesOut:Number = 0;
		
		public static function getInstance():CoolItModelLocator {
			if(modelLocator == null) {
				modelLocator = new CoolItModelLocator();
			}
      		
			return modelLocator;
		}
		
		public function CoolItModelLocator() {	
			if(modelLocator != null) {
				throw new Error( "Only one CoolItModelLocator instance should be instantiated" );	
			}
			
			stateModel = new StateModel();
			cryoLibModel = new CryoLibModel();
		}
		
		public function removeNamespaces(data_p:*):XML {
			var serializedXML:String;
			var responseData:Object;
			var cleanedString:String;
			var cleanedXML:XML;
			var namespaceRegExp:RegExp = new RegExp("xmlns[^\"]*\"[^\"]*\"", "gi");
			
			if(data_p is XMLList) {
				responseData = data_p as XMLList;
			} else {
				responseData = data_p as XML;
			}
			
			serializedXML = responseData.toXMLString();
			
			cleanedString = serializedXML.replace(namespaceRegExp, "");
			cleanedXML = new XML(cleanedString);
			
			return cleanedXML;
		}
		
	}
}