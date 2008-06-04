package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class EnterCutScreenEvent extends CairngormEvent {
		public static var EVENT_ENTER_CUT:String = "edu.wisc.doit.ls.coolit.event.EnterCutScreenEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var nextStateName:String;
		public var source:*;
		
		/**
		 * Constructor.
		 */
		public function EnterCutScreenEvent() {
			super(EVENT_ENTER_CUT);
		}
		
		
	}
	
}