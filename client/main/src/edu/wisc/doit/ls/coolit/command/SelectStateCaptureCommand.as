package edu.wisc.doit.ls.coolit.command {
	import mx.rpc.IResponder;
	
	import flash.utils.*;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.business.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	import edu.wisc.doit.ls.coolit.CommonBase;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import mx.collections.ArrayCollection;
	import mx.graphics.Stroke;
	
	/**
	 * 
	 */
	public class SelectStateCaptureCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function SelectStateCaptureCommand() {
			super();
		}
		
		public function execute(event:CairngormEvent):void {
			var selectCaptureEvent:SelectStateCaptureEvent = event as SelectStateCaptureEvent;
			model = selectCaptureEvent.modelLocator;
			var coolerModel:CoolerModel = model.coolerModel;
			var materialModel:MaterialModel = model.materialModel;
			
			var stateSnapshot:StateSnapshotVO = selectCaptureEvent.stateSnapshot;
			
			coolerModel.selected = stateSnapshot.cooler;
			materialModel.selected = stateSnapshot.material;
			model.powerFactor = stateSnapshot.powerFactor;
			model.strutLength = stateSnapshot.strutLength;
			model.crossSection = stateSnapshot.crossSection;
			
			model.stateSnapshot = stateSnapshot;
			
			dispatchSetCooler(stateSnapshot.cooler, stateSnapshot.powerFactor);
			dispatchSetStrut(stateSnapshot.material, stateSnapshot.strutLength, stateSnapshot.crossSection);
		}
		
		public function result(event:Object):void {}
		
		public function fault(event:Object):void {}
		
		public function dispatchSetCooler(cooler_p:CoolerVO, powerFactor_p:Number):void {
			//send out a set cooler event with currently selected cooler
			var setCoolerEvent:SetCoolerEvent = new SetCoolerEvent();
			setCoolerEvent.modelLocator = model;
			setCoolerEvent.cooler = cooler_p;
			setCoolerEvent.powerFactor = powerFactor_p;
			setCoolerEvent.powerSetting = model.powerSetting;
			CairngormEventDispatcher.getInstance().dispatchEvent(setCoolerEvent);
		}
		
		private function dispatchRunSimEvent():void {
			var runSimEvent:RunSimulationEvent = new RunSimulationEvent();
			runSimEvent.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(runSimEvent);
		}
		
		public function dispatchSetStrut(material_p:MaterialVO, length_p:Number, crossSection_p:Number):void {
			//send out a set cooler event with currently selected cooler
			
			var setStrutEvent:SetStrutEvent = new SetStrutEvent();
			setStrutEvent.modelLocator = model;
			setStrutEvent.material = material_p;
			setStrutEvent.length = length_p;
			setStrutEvent.crossSection = crossSection_p;
			CairngormEventDispatcher.getInstance().dispatchEvent(setStrutEvent);
		}
	}
	
}