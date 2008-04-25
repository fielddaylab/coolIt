package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class GetCoolerListEvent extends CairngormEvent {
		public static var EVENT_GET_COOLER_LIST:String = "edu.wisc.doit.ls.coolit.event.GetCoolerListEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function GetCoolerListEvent() {
			super(EVENT_GET_COOLER_LIST);
		}
		
		
	}
	
}