package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class ChangeWorkAreaStateEvent extends CairngormEvent {
		public static var EVENT_CHANGE_WORK_STATE:String = "edu.wisc.doit.ls.coolit.event.ChangeWorkAreaStateEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var stateName:String;
		
		/**
		 * Constructor.
		 */
		public function ChangeWorkAreaStateEvent() {
			super(EVENT_CHANGE_WORK_STATE);
		}
		
		
	}
	
}