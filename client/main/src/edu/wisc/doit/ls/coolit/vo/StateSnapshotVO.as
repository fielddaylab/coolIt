package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	import mx.collections.ArrayCollection;
	import mx.graphics.Stroke;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	public class StateSnapshotVO implements IValueObject {
		
		//main state vars
		public var id:String;
		public var cooler:CoolerVO;
		public var material:MaterialVO;
		public var powerFactor:Number;
		public var strutLength:Number;
		public var crossSection:Number;
		
		public var captureData:ArrayCollection;
				
		public var highestDataValue:Number;
		public var highestCoolingValue:Number;
		public var highestHeatLeakValue:Number;
		
		public var coolerStroke:Stroke;
		public var heatLeakStroke:Stroke;
		public var label:String;
		
		public function StateSnapshotVO(id_p:Number) {
			id = id_p.toString();
		}
		
		public function get description():String {
			//start with material
			var desc:String = "Material: " + material + ", Strut Length: " + strutLength + 
								", X-Section: " + crossSection + ", Cooler: " + cooler + 
								", Power Factor: " + powerFactor;
			return desc;
		}
		public function set description(desc_p:String):void {
			//nada
		}
	}
	
}