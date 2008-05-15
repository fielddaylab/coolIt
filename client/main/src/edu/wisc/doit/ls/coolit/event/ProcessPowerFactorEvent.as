package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class ProcessPowerFactorEvent extends CairngormEvent {
		public static var EVENT_PROCESS_POWER_FACTOR:String = "edu.wisc.doit.ls.coolit.event.ProcessPowerFactorEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function ProcessPowerFactorEvent() {
			super(EVENT_PROCESS_POWER_FACTOR);
		}
		
	}
	
}