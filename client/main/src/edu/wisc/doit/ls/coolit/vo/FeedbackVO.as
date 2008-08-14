package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	public class FeedbackVO implements IValueObject {
		public static var SUCCESS:String = "Success";
		public static var POWER_LIMIT:String = "PowerLimitExceeded";
		public static var TOO_HOT:String = "TooHot";
		public static var STRUT_BREAKS:String = "StrutBreaks";
		
		private var core:XML;
		
		public function FeedbackVO(core_p:XML) {
			super();
			core = core_p;
		}
		
		public function get text():String { return core.GetFeedbackResult.Text; };
		public function set text(text_p:String):void { /* nada */ };
		
		public function get cutScreen():String { return core.GetFeedbackResult.CutScreen.toString(); };
		public function set cutScreen(screen_p:String):void { /* nada */ };
	}
	
}