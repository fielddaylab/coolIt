package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	import edu.wisc.doit.ls.coolit.vo.MaterialVO;
	
	public class SetStrutEvent extends CairngormEvent {
		public static var EVENT_SET_STRUT:String = "edu.wisc.doit.ls.coolit.event.SetStrutEvent";
		
		public var modelLocator:CoolItModelLocator;
		public var material:MaterialVO;
		public var length:Number;
		public var crossSection:Number;
		
		/**
		 * Constructor.
		 */
		public function SetStrutEvent() {
			super(EVENT_SET_STRUT);
		}
		
		
	}
	
}