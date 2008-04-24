package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.vo.JobVO;
	
	public class ChooseJobEvent extends CairngormEvent {
		public static var EVENT_CHOOSE_JOB:String = "edu.wisc.doit.ls.coolit.event.ChooseJobEvent";
		
		public var job:JobVO;
		
		/**
		 * Constructor.
		 */
		public function ChooseJobEvent() {
			super(EVENT_CHOOSE_JOB);
		}
		
		
	}
	
}