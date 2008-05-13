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
		[Bindable] public var coolerModel:CoolerModel;
		
		private var powerFactorDown:Boolean = false;
		
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
			setCoolerEvent.powerSetting = (inputPower.selected) ? CoolerModel.INPUT_POWER : CoolerModel.OUTPUT_POWER;
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
			inputPower.addEventListener(Event.CHANGE, onSettingChange);
			outputPower.addEventListener(Event.CHANGE, onSettingChange);
			coolerPowerFactor.addEventListener(SliderEvent.CHANGE, onSliderChange);
			coolerPowerFactor.addEventListener(MouseEvent.MOUSE_DOWN, onPowerFactorDown);
			coolerPowerFactor.addEventListener(MouseEvent.MOUSE_UP, onPowerFactorUp);
			coolerPowerFactor.addEventListener(MouseEvent.MOUSE_MOVE, onPowerFactorMove);
		}
		
		private function onSliderChange(event_p:SliderEvent):void {
			//dispatch get power data
			//log.debug("{0} - onSliderChange called, calling dispatchGetPowerDataEvent", getQualifiedClassName(this) + ".onComplete");
			//dispatchGetPowerDataEvent();
			dispatchSetCooler();
		}
		
		private function onPowerFactorDown(event_p:MouseEvent):void {
			powerFactorDown = true;
		}
		
		private function onPowerFactorUp(event_p:MouseEvent):void {
			powerFactorDown = false;
			//dispatchGetPowerDataEvent();
			dispatchSetCooler();
		}
		
		private function onPowerFactorMove(event_p:MouseEvent):void {
			if(powerFactorDown) {
				//dispatchGetPowerDataEvent();
				dispatchSetCooler();
			}
		}
		
		private function onSettingChange(event_p:Event):void {
			//dispatch get power data
			//dispatchGetPowerDataEvent();
			dispatchSetCooler();
		}
		
		private function onCoolerChange(event_p:Event):void {
			dispatchSetCooler();
		}
		
		private function dispatchGetPowerDataEvent():void {
			//send out a set cooler event with currently selected cooler
			if(inputPower.selected) {
				dispatchEventGetInputPowerData();
			} else {
				dispatchEventGetOutputPowerData();
			}
		}
		
		private function dispatchRunSimEvent():void {
			var runSimEvent:RunSimulationEvent = new RunSimulationEvent();
			runSimEvent.modelLocator = modelLocator;
			CairngormEventDispatcher.getInstance().dispatchEvent(runSimEvent);
		}
		
		private function dispatchEventGetOutputPowerData():void {
			var getOutputPowerData:GetOutputPowerDataEvent = new GetOutputPowerDataEvent();
			getOutputPowerData.modelLocator = modelLocator;
			getOutputPowerData.coolerName = coolerList.selectedItem.name;
			getOutputPowerData.powerFactor = coolerPowerFactor.value;
			CairngormEventDispatcher.getInstance().dispatchEvent(getOutputPowerData);
		}
		
		private function dispatchEventGetInputPowerData():void {
			var getInputPowerData:GetInputPowerDataEvent = new GetInputPowerDataEvent();
			getInputPowerData.modelLocator = modelLocator;
			getInputPowerData.coolerName = coolerList.selectedItem.name;
			getInputPowerData.powerFactor = coolerPowerFactor.value;
			CairngormEventDispatcher.getInstance().dispatchEvent(getInputPowerData);
		}
	}
}