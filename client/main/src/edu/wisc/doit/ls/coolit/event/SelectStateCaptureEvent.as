package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	import edu.wisc.doit.ls.coolit.vo.StateSnapshotVO;
	
	public class SelectStateCaptureEvent extends CairngormEvent {
		public static var EVENT_SELECT_CAPTURE:String = "edu.wisc.doit.ls.coolit.event.SelectStateCaptureEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var stateSnapshot:StateSnapshotVO;
		
		/**
		 * Constructor.
		 */
		public function SelectStateCaptureEvent() {
			super(EVENT_SELECT_CAPTURE);
		}
		
		
	}
	
}