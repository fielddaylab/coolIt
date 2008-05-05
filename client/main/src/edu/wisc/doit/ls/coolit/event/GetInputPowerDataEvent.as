package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class GetInputPowerDataEvent extends CairngormEvent {
		public static var EVENT_GET_INPUT_POWER:String = "edu.wisc.doit.ls.coolit.event.GetInputPowerDataEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var coolerName:String;
		public var powerFactor:Number;
		
		/**
		 * Constructor.
		 */
		public function GetInputPowerDataEvent() {
			super(EVENT_GET_INPUT_POWER);
		}
		
		
	}
	
}