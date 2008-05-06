package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class CommitSolutionEvent extends CairngormEvent {
		public static var EVENT_COMMIT_SOLUTION:String = "edu.wisc.doit.ls.coolit.event.CommitSolutionEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function CommitSolutionEvent() {
			super(EVENT_COMMIT_SOLUTION);
		}
		
		
	}
	
}