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
		[Bindable] public var crossSectionDisplay:Label;
		[Bindable] public var lengthDisplay:Label;
		[Bindable] public var graphView:Graph;
		
		[Bindable] public var model:ArrayCollection;
		[Bindable] public var materialData:ArrayCollection;
		[Bindable] public var modelLocator:CoolItModelLocator;
		[Bindable] public var materialModel:MaterialModel;
		
		private var crossSectionDown:Boolean = false;
		private var lengthDown:Boolean = false;
		
		private var _selected:Boolean = false;
		
		private var runSimDelay:Timer;
		
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function StrutPickerView():void {
			super();
			
			runSimDelay = new Timer(500, 1);
            runSimDelay.addEventListener(TimerEvent.TIMER, onRunSimDelay);
			
			
			//set up logging
			log = Log.getLogger(ApplicationClass.APP_CATEGORY);
			log.debug("{0} - View instantiated", getQualifiedClassName(this));
			
			addEventListener(FlexEvent.CREATION_COMPLETE, onComplete);
		}
		
		public function dispatchSetStrut(doRunSim_p:Boolean = false):void {
			//send out a set cooler event with currently selected cooler
			
			var setStrutEvent:SetStrutEvent = new SetStrutEvent();
			setStrutEvent.modelLocator = modelLocator;
			setStrutEvent.material = strutList.selectedItem as MaterialVO;
			setStrutEvent.length = lengthM.value;
			setStrutEvent.crossSection = crossSection.value;
			setStrutEvent.doRunSim = doRunSim_p;
			CairngormEventDispatcher.getInstance().dispatchEvent(setStrutEvent);
		}
		
		[Bindable] public function get selected():Boolean {
			return _selected;
		}
		public function set selected(selected_p:Boolean):void {
			if(selected_p) {
				graphView.refresh();
			}
			_selected = selected_p;
		}
		
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
		private function onComplete(event_p:FlexEvent):void {
			log.debug("{0} - creationComplete called", getQualifiedClassName(this) + ".onComplete");
			
			strutList.addEventListener(Event.CHANGE, onStrutChange);
			lengthM.addEventListener(SliderEvent.CHANGE, onSliderChange);
			crossSection.addEventListener(SliderEvent.CHANGE, onSliderChange);
			crossSection.addEventListener(MouseEvent.MOUSE_DOWN, onCrossSectionDown);
			//crossSection.addEventListener(MouseEvent.MOUSE_UP, onCrossSectionUp);
			crossSection.addEventListener(MouseEvent.MOUSE_MOVE, onCrossSectionMove);
			//crossSection.addEventListener(MouseEvent.MOUSE_OUT, onCrossSectionOut);
			
			lengthM.addEventListener(MouseEvent.MOUSE_DOWN, onLengthDown);
			//lengthM.addEventListener(MouseEvent.MOUSE_UP, onLengthUp);
			lengthM.addEventListener(MouseEvent.MOUSE_MOVE, onLengthMove);
			//lengthM.addEventListener(MouseEvent.MOUSE_OUT, onLengthOut);
		}
		
		public function reset():void {
			strutList.selectedIndex = 0;
			dispatchSetStrut(true);
		}
		
		private function onRunSimDelay(event_p:TimerEvent):void {
			dispatchSetStrut(true);
		}
		
		private function onSliderChange(event_p:SliderEvent):void {
			crossSectionDisplay.text = crossSection.value.toString();
			lengthDisplay.text = lengthM.value.toString();
			dispatchSetStrut(false);
		}
		
		private function onCrossSectionDown(event_p:MouseEvent):void {
			crossSectionDown = true;
			stage.addEventListener(MouseEvent.MOUSE_UP, onCheckMouseOutCrossSection);
		}
		
		private function onCheckMouseOutCrossSection(event_p:MouseEvent):void {
			crossSectionDown = false;
			crossSectionDisplay.text = crossSection.value.toString();
			dispatchSetStrut(true);
			
			runSimDelay.reset();
			runSimDelay.start();
			
			stage.removeEventListener(MouseEvent.MOUSE_UP, onCheckMouseOutCrossSection);
		}
		
		private function onCrossSectionUp(event_p:MouseEvent):void {
			crossSectionDown = false;
			crossSectionDisplay.text = crossSection.value.toString();
			dispatchSetStrut(true);
		}
		
		private function onCrossSectionOut(event_p:MouseEvent):void {
			crossSectionDown = false;
			//dispatchSetStrut(true);
		}
		
		private function onCrossSectionMove(event_p:MouseEvent):void {
			crossSectionDisplay.text = crossSection.value.toString()
			if(crossSectionDown) {
				dispatchSetStrut(false);
			}
		}
		
		private function onLengthDown(event_p:MouseEvent):void {
			lengthDown = true;
			stage.addEventListener(MouseEvent.MOUSE_UP, onCheckMouseOutLength);
		}
		
		private function onCheckMouseOutLength(event_p:MouseEvent):void {
			lengthDisplay.text = lengthM.value.toString();
			lengthDown = false;
			dispatchSetStrut(true);
			
			runSimDelay.reset();
			runSimDelay.start();
			
			stage.removeEventListener(MouseEvent.MOUSE_UP, onCheckMouseOutLength);
		}
		
		private function onLengthOut(event_p:MouseEvent):void {
			lengthDown = false;
			//dispatchSetStrut(true);
		}
		
		private function onLengthUp(event_p:MouseEvent):void {
			lengthDisplay.text = lengthM.value.toString();
			lengthDown = false;
			dispatchSetStrut(true);
		}
		
		private function onLengthMove(event_p:MouseEvent):void {
			lengthDisplay.text = lengthM.value.toString();
			if(lengthDown) {
				dispatchSetStrut(false);
			}
		}
		
		private function dispatchRunSimEvent():void {
			var runSimEvent:RunSimulationEvent = new RunSimulationEvent();
			runSimEvent.modelLocator = modelLocator;
			CairngormEventDispatcher.getInstance().dispatchEvent(runSimEvent);
		}
		
		private function onStrutChange(event_p:Event):void {
			dispatchSetStrut(true);
		}
	}
}