package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class LeaveCutScreenEvent extends CairngormEvent {
		public static var EVENT_LEAVE_CUT:String = "edu.wisc.doit.ls.coolit.event.LeaveCutScreenEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function LeaveCutScreenEvent() {
			super(EVENT_LEAVE_CUT);
		}
		
		
	}
	
}