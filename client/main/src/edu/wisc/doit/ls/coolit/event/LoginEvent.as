package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.vo.JobVO;
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class LoginEvent extends CairngormEvent {
		public static var EVENT_LOGIN:String = "edu.wisc.doit.ls.coolit.event.LoginEvent";
		
		public var accountId:String;
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function LoginEvent() {
			super(EVENT_LOGIN);
		}
		
		
	}
	
}