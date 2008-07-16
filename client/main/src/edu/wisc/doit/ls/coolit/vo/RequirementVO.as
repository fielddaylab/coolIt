package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	public class RequirementVO implements IValueObject {
		
		public var core:XML;
		
		private var opTable:Object;
		
		private var labelTable:Object;
		
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
		
		public function toString():String {
			return "(" + operation + "," + label + "," + target + ")";
		}
	}
	
}