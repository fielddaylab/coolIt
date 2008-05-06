package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.VBox;
	import mx.events.*;
	
	import mx.logging.ILogger;
	import mx.logging.Log;
	
	import flash.events.*;
	import flash.utils.*;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	import mx.collections.ArrayCollection;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class StrutPickerView extends VBox {		
		
		//MXML components
		[Bindable] public var strutList:ComboBox;
		[Bindable] public var lengthM:HSlider;
		[Bindable] public var crossSection:HSlider;
		
		[Bindable] public var model:ArrayCollection;
		[Bindable] public var materialData:ArrayCollection;
		[Bindable] public var modelLocator:CoolItModelLocator;
		[Bindable] public var materialModel:MaterialModel;
		
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function StrutPickerView():void {
			super();
			
			//set up logging
			log = Log.getLogger(ApplicationClass.APP_CATEGORY);
			log.debug("{0} - View instantiated", getQualifiedClassName(this));
			
			addEventListener(FlexEvent.CREATION_COMPLETE, onComplete);
		}
		
		public function dispatchSetStrut():void {
			//send out a set cooler event with currently selected cooler
			
			var setStrutEvent:SetStrutEvent = new SetStrutEvent();
			setStrutEvent.modelLocator = modelLocator;
			setStrutEvent.material = strutList.selectedItem as MaterialVO;
			setStrutEvent.length = lengthM.value;
			setStrutEvent.crossSection = crossSection.value;
			CairngormEventDispatcher.getInstance().dispatchEvent(setStrutEvent);
		}
		
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
		private function onComplete(event_p:FlexEvent):void {
			log.debug("{0} - creationComplete called", getQualifiedClassName(this) + ".onComplete");
			
			strutList.addEventListener(Event.CHANGE, onStrutChange);
		}
		
		private function onStrutChange(event_p:Event):void {
			dispatchSetStrut();
		}
	}
}