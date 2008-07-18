package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class UpdateStateCaptureEvent extends CairngormEvent {
		public static var EVENT_UPDATE_CAPTURE:String = "edu.wisc.doit.ls.coolit.event.UpdateStateCaptureEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function UpdateStateCaptureEvent() {
			super(EVENT_UPDATE_CAPTURE);
		}
		
		
	}
	
}