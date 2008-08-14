package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	public class RequirementVO implements IValueObject {
		public static var STRUT_LENGTH:String = "STRUT_LENGTH";
		public static var STRUT_CROSS_SECTION:String = "STRUT_CROSS_SECTION";
		public static var FORCE_LIMIT:String = "FORCE_LIMIT";
		public static var INPUT_POWER:String = "INPUT_POWER";
		public static var TEMP:String = "TEMP";
		public static var GREATER_THAN_OR_EQUAL:String = "GE";
		public static var LESS_THAN_OR_EQUAL:String = "LE";
		public static var GREATER_THAN:String = "GT";
		public static var LESS_THAN:String = "LT";
		
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
			unitTable["STRUT_LENGTH"] = "(M)";
			unitTable["STRUT_CROSS_SECTION"] = "(m^2)";
			unitTable["FORCE_LIMIT"] = "(kN)";
			unitTable["INPUT_POWER"] = "(W)";
			unitTable["TEMP"] = "(K)";
		}
		
		public function get operation():String { return opTable[core.@Op]; };
		public function set operation(op_p:String):void { /* nada */ };
		
		public function get value():String { return core.@Value; };
		public function set value(value_p:String):void { /* nada */ };
		
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
		
		public function valuePasses(value_p:Number):Boolean {
			var passes:Boolean = false;
			
			switch(core.@Op.toString()) {
				case GREATER_THAN_OR_EQUAL:
					if(value_p >= target) {
						passes = true;
					}
					break;
				case LESS_THAN_OR_EQUAL:
					if(value_p <= target) {
						passes = true;
					}
					break;
				case GREATER_THAN:
					if(value_p > target) {
						passes = true;
					}
					break;
				case LESS_THAN:
					if(value_p < target) {
						passes = true;
					}
					break;
				default:
					break;
			}
			
			return passes;
		}
		
		public function toString():String {
			return "(" + operation + "," + label + "," + target + ")";
		}
	}
	
}