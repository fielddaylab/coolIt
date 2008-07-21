package edu.wisc.doit.ls.coolit.model {
	import com.adobe.cairngorm.model.ModelLocator;
	
	import edu.wisc.doit.ls.coolit.*;
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	import mx.collections.ArrayCollection;
	
	[Bindable]
	public class CoolItModelLocator implements ModelLocator {
		private static var modelLocator:CoolItModelLocator;
		
		public var runSimCount:Number = 0;
		
		public var bankBalance:Number = 1500;
		public var temperature:Number;
		public var inputPower:Number;
		public var cost:Number;
		public var stressLimit:Number;
		public var isValidSolution:Boolean;
		public var powerFactor:Number;
		public var strutLength:Number;
		public var crossSection:Number;
		public var powerSetting:String;
		
		public var stateSnapshot:StateSnapshotVO;
		public var snapshotList:ArrayCollection;
		
		public var sketchData:ArrayCollection;
		
		public var jobModel:JobModel;
		public var coolerModel:CoolerModel;
		public var materialModel:MaterialModel;
		public var stateModel:StateModel;
		public var cryoLibModel:CryoLibModel;
		public var graphColorModel:GraphColorModel;
		
		public var servicesOut:Number = 0;
		
		public var sketchCount:Number;
		
		
		//power factor sketch pad parameters
		private var powerFactorMax:Number = 1;
		private var powerFactorMin:Number = 0.01;
		private var powerFactorResolution:Number = 50;
		private var powerFactorSpread:Number = powerFactorMax - powerFactorMin;
		private var powerFactorUnit:Number = powerFactorSpread/powerFactorResolution;
		
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
			sketchData = new ArrayCollection();
			graphColorModel = new GraphColorModel();
			powerFactor = CoolerModel.DEFAULT_POWER_FACTOR;
			strutLength = MaterialModel.DEFAULT_LENGTH;
			crossSection = MaterialModel.DEFAULT_CROSS_SECTION;
			
			//set up default state snapshot
			stateSnapshot = new StateSnapshotVO();
			snapshotList = new ArrayCollection();
			snapshotList.addItem(stateSnapshot);
		}
		
		public function updateSketchData():void {
			if(stateModel.workAreaState == StateModel.SKETCH_STATE) {
				switch (stateModel.sketchState) {
					case StateModel.POWER_FACTOR:
						var newDPXML:XML =  <DataPoint><temp>{temperature}</temp><data>{powerFactor}</data></DataPoint>;
						var newDataPoint:DataPointVO = new DataPointVO(newDPXML);
						sketchData.addItem(newDataPoint);
						break;
					case StateModel.STRUT_LENGTH:
						
						break;
					case StateModel.STRUT_CROSS_SECTION:
						
						break;
					default:
						break;
				}
			}
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