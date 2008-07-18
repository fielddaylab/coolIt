package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class AddNewStateCaptureEvent extends CairngormEvent {
		public static var EVENT_ADD_CAPTURE:String = "edu.wisc.doit.ls.coolit.event.AddNewStateCaptureEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function AddNewStateCaptureEvent() {
			super(EVENT_ADD_CAPTURE);
		}
		
		
	}
	
}