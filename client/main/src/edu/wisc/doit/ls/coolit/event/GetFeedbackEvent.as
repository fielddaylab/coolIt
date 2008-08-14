package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class GetFeedbackEvent extends CairngormEvent {
		public static var EVENT_GET_FEEDBACK:String = "edu.wisc.doit.ls.coolit.event.GetFeedbackEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function GetFeedbackEvent() {
			super(EVENT_GET_FEEDBACK);
		}
		
	}
	
}