package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	public class JobVO implements IValueObject {
		
		private var core:XML;
				
		public function JobVO(core_p:XML) {
			super();
			core = core_p;
		}
		
		public function get name():String { return core.@Name; };
		public function set name(name_p:String):void { /* nada */ };
		
		public function get description():String { return core.Description; };
		public function set description(description_p:String):void { /* nada */ };
		
		public function get pay():Number { return parseFloat(core.MonetaryIncentive); };
		public function set pay(pay_p:Number):void { /* nada */ };
		
		public function get heatLeak():Number { return parseFloat(core.HeatLeak); };
		public function set heatLeak(heat_p:Number):void { /* nada */ };
		
		public function get supportMode():String { return core.SupportMode; };
		public function set supportMode(mode_p:String):void { /* nada */ };
		
		public function get minimumStrutLength():Number { return parseFloat(core.MinStrutLength); };
		public function set minimumStrutLength(length_p:Number):void { /* nada */ };
		
		public function get maximumStrutLength():Number { return parseFloat(core.MaxStrutLength); };
		public function set maximumStrutLength(length_p:Number):void { /* nada */ };
		
		public function get supportNumber():Number { return parseFloat(core.SupportNumber); };
		public function set supportNumber(length_p:Number):void { /* nada */ };
		
		public function get solved():Boolean { return (core.Solved.toLowerCase() == "true") ? true : false; };
		public function set solved(solved_p:Boolean):void { /* nada */ };
		
		public function toString():String {
			return name;
		}
	}
	
}