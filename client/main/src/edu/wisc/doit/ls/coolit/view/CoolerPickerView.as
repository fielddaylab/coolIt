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
	public class CoolerPickerView extends VBox {		
		
		//MXML components
		[Bindable] public var inputPower:RadioButton;
		[Bindable] public var outputPower:RadioButton;
		[Bindable] public var coolerList:ComboBox;
		[Bindable] public var coolerPowerFactor:HSlider;
		
		[Bindable] public var modelLocator:CoolItModelLocator;
		[Bindable] public var model:ArrayCollection;
		[Bindable] public var coolerData:ArrayCollection;
		
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function CoolerPickerView():void {
			super();
			
			//set up logging
			log = Log.getLogger(ApplicationClass.APP_CATEGORY);
			log.debug("{0} - View instantiated", getQualifiedClassName(this));
			
			addEventListener(FlexEvent.CREATION_COMPLETE, onComplete);
		}
		
		public function dispatchSetCooler():void {
			//send out a set cooler event with currently selected cooler
			var setCoolerEvent:SetCoolerEvent = new SetCoolerEvent();
			setCoolerEvent.modelLocator = modelLocator;
			setCoolerEvent.cooler = coolerList.selectedItem as CoolerVO;
			setCoolerEvent.powerFactor = coolerPowerFactor.value;
			CairngormEventDispatcher.getInstance().dispatchEvent(setCoolerEvent);
		}
		
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
		private function onComplete(event_p:FlexEvent):void {
			log.debug("{0} - creationComplete called", getQualifiedClassName(this) + ".onComplete");
			
			coolerList.addEventListener(Event.CHANGE, onCoolerChange);
		}
		
		private function onCoolerChange(event_p:Event):void {
			dispatchSetCooler();
		}
	}
}