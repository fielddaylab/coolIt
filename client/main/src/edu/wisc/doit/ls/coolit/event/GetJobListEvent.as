package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class GetJobListEvent extends CairngormEvent {
		public static var EVENT_GET_JOB_LIST:String = "edu.wisc.doit.ls.coolit.event.GetJobListEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function GetJobListEvent() {
			super(EVENT_GET_JOB_LIST);
		}
		
		
	}
	
}