package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class SetCoolerEvent extends CairngormEvent {
		public static var EVENT_SET_COOLER:String = "edu.wisc.doit.ls.coolit.event.SetCoolerEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var coolerName:String;
		public var powerFactor:Number;
		
		/**
		 * Constructor.
		 */
		public function SetCoolerEvent() {
			super(EVENT_SET_COOLER);
		}
		
		
	}
	
}