package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class ClearStateCapturesEvent extends CairngormEvent {
		public static var EVENT_CLEAR_CAPTURES:String = "edu.wisc.doit.ls.coolit.event.ClearStateCapturesEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function ClearStateCapturesEvent() {
			super(EVENT_CLEAR_CAPTURES);
		}
		
		
	}
	
}