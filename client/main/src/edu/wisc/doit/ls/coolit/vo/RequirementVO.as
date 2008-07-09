package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	public class RequirementVO implements IValueObject {
		
		public var core:XML;
		
		private var opTable:Object;
		
		public function RequirementVO(core_p:XML) {
			super();
			core = core_p;
			opTable = new Object();
			opTable["GE"] = "&gt;=";
			opTable["LE"] = "&lt;=";
			opTable["GT"] = "&gt;";
			opTable["LT"] = "&lt;";
		}
		
		public function get operation():String { return opTable[core.@Op]; };
		public function set operation(op_p:String):void { /* nada */ };
		
		public function get label():String { return core.@Value; };
		public function set label(label_p:String):void { /* nada */ };
		
		public function get target():Number { return parseFloat(core.@Target); };
		public function set target(target_p:Number):void { /* nada */ };
		
		public function toString():String {
			return "(" + operation + "," + label + "," + target + ")";
		}
	}
	
}