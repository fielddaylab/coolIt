package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	public class RequirementVO implements IValueObject {
		
		public var core:XML;
		
		private var opTable:Object;
		
		private var labelTable:Object;
		private var unitTable:Object;
		
		public function RequirementVO(core_p:XML) {
			super();
			core = core_p;
			opTable = new Object();
			opTable["GE"] = "&gt;=";
			opTable["LE"] = "&lt;=";
			opTable["GT"] = "&gt;";
			opTable["LT"] = "&lt;";
			
			labelTable = new Object();
			labelTable["STRUT_LENGTH"] = "Strut Length";
			labelTable["STRUT_CROSS_SECTION"] = "Strut Cross Section";
			labelTable["FORCE_LIMIT"] = "Force Limit";
			labelTable["INPUT_POWER"] = "Input Power";
			labelTable["TEMP"] = "Temp";
			
			unitTable = new Object();
			unitTable["STRUT_LENGTH"] = "(m)";
			unitTable["STRUT_CROSS_SECTION"] = "(m^2)";
			unitTable["FORCE_LIMIT"] = "(mN)";
			unitTable["INPUT_POWER"] = "(W)";
			unitTable["TEMP"] = "(K)";
		}
		
		public function get operation():String { return opTable[core.@Op]; };
		public function set operation(op_p:String):void { /* nada */ };
		
		public function get label():String { 
			var newLabel:String;
			if(labelTable[core.@Value]) {
				newLabel = labelTable[core.@Value];
			} else {
				newLabel = core.@Value;
			}
			
			return newLabel; 
		};
		public function set label(label_p:String):void { /* nada */ };
		
		public function get target():Number { return parseFloat(core.@Target); };
		public function set target(target_p:Number):void { /* nada */ };
		
		public function get unit():String { return unitTable[core.@Value]; };
		public function set unit(unit_p:String):void { /* nada */ };
		
		public function toString():String {
			return "(" + operation + "," + label + "," + target + ")";
		}
	}
	
}