package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	import edu.wisc.doit.ls.coolit.vo.CoolerVO;
	
	public class SetCoolerEvent extends CairngormEvent {
		public static var EVENT_SET_COOLER:String = "edu.wisc.doit.ls.coolit.event.SetCoolerEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var cooler:CoolerVO;
		public var powerFactor:Number;
		public var powerSetting:String;
		
		/**
		 * Constructor.
		 */
		public function SetCoolerEvent() {
			super(EVENT_SET_COOLER);
		}
		
		
	}
	
}