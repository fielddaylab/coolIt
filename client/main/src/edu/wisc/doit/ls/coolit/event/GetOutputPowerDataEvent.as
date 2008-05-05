package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class GetOutputPowerDataEvent extends CairngormEvent {
		public static var EVENT_GET_OUTPUT_POWER:String = "edu.wisc.doit.ls.coolit.event.GetOutputPowerDataEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var coolerName:String;
		public var powerFactor:Number;
		
		/**
		 * Constructor.
		 */
		public function GetOutputPowerDataEvent() {
			super(EVENT_GET_OUTPUT_POWER);
		}
		
		
	}
	
}