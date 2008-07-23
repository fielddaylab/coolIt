package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	import edu.wisc.doit.ls.coolit.vo.StateSnapshotVO;
	
	public class SetSimulationModeEvent extends CairngormEvent {
		public static var EVENT_SET_SIM_MODE:String = "edu.wisc.doit.ls.coolit.event.SetSimulationModeEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var mode:String;
		
		/**
		 * Constructor.
		 */
		public function SetSimulationModeEvent() {
			super(EVENT_SET_SIM_MODE);
		}
		
		
	}
	
}