package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class RemoveStateCaptureEvent extends CairngormEvent {
		public static var EVENT_REMOVE_CAPTURE:String = "edu.wisc.doit.ls.coolit.event.RemoveStateCaptureEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function RemoveStateCaptureEvent() {
			super(EVENT_REMOVE_CAPTURE);
		}
		
		
	}
	
}