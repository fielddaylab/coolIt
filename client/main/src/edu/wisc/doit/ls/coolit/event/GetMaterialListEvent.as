package edu.wisc.doit.ls.coolit.event {
	import flash.events.Event;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.CoolItModelLocator;
	
	public class GetMaterialListEvent extends CairngormEvent {
		public static var EVENT_GET_MATERIAL_LIST:String = "edu.wisc.doit.ls.coolit.event.GetMaterialListEvent";
		
		public var modelLocator:CoolItModelLocator;
		
		/**
		 * Constructor.
		 */
		public function GetMaterialListEvent() {
			super(EVENT_GET_MATERIAL_LIST);
		}
		
		
	}
	
}