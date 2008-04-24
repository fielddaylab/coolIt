package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.vo.JobVO;
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class ChooseJobEvent extends CairngormEvent {
		public static var EVENT_CHOOSE_JOB:String = "edu.wisc.doit.ls.coolit.event.ChooseJobEvent";
		
		public var job:JobVO;
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function ChooseJobEvent() {
			super(EVENT_CHOOSE_JOB);
		}
		
		
	}
	
}