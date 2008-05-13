package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class GetSpecificPowerDataEvent extends CairngormEvent {
		public static var EVENT_GET_POWER:String = "edu.wisc.doit.ls.coolit.event.GetSpecificPowerDataEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function GetSpecificPowerDataEvent() {
			super(EVENT_GET_POWER);
		}
		
	}
	
}