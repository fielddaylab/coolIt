package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	public class RequirementVO implements IValueObject {
		
		public var core:XML;
		
		public function RequirementVO(core_p:XML) {
			super();
			core = core_p;
		}
		
		public function get operation():String { return core.@Op; };
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