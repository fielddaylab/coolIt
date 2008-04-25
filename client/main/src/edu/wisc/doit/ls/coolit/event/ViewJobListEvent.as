package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class ViewJobListEvent extends CairngormEvent {
		public static var EVENT_VIEW_JOB_LIST:String = "edu.wisc.doit.ls.coolit.event.ViewJobListEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function ViewJobListEvent() {
			super(EVENT_VIEW_JOB_LIST);
		}
		
		
	}
	
}