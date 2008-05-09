package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class SetProblemEvent extends CairngormEvent {
		public static var EVENT_SET_PROBLEM:String = "edu.wisc.doit.ls.coolit.event.SetProblemEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var problemName:String;
		
		/**
		 * Constructor.
		 */
		public function SetProblemEvent() {
			super(EVENT_SET_PROBLEM);
		}
		
		
	}
	
}