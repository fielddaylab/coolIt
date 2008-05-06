package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class RunSimulationEvent extends CairngormEvent {
		public static var EVENT_RUN_SIM:String = "edu.wisc.doit.ls.coolit.event.RunSimulationEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function RunSimulationEvent() {
			super(EVENT_RUN_SIM);
		}
		
		
	}
	
}