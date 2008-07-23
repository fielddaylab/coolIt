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
	public class UpdateStateCaptureCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function UpdateStateCaptureCommand() {
			super();
		}
		
		public function execute(event:CairngormEvent):void {
			var updateCaptureEvent:UpdateStateCaptureEvent = event as UpdateStateCaptureEvent;
			model = updateCaptureEvent.modelLocator;
			var coolerModel:CoolerModel = model.coolerModel;
			var materialModel:MaterialModel = model.materialModel;
			var graphColorModel:GraphColorModel = model.graphColorModel;
			
			if(materialModel && coolerModel.outputPowerData) {
				
				var selectedMaterial:MaterialVO = materialModel.selected;
				//we can loop through pre-existing output cooler data
				//and re-use that calculated data instead of calculating again
				//we also use the output power data item's temp
				//we also calc heat leak
				var outputPowerData:ArrayCollection = coolerModel.outputPowerData;
				var outputLen:Number = outputPowerData.length;
				var captureData:Array = new Array();
				var highestValue:Number = 0;
				var highestCooling:Number = 0;
				var highestHeat:Number = 0;
				for(var i:Number = 0; i<outputLen; i++) {
					var curOutputItem:DataPointVO = outputPowerData.getItemAt(i) as DataPointVO;
					var curTemp:Number = curOutputItem.temp;
					var curCoolWatts:Number = (curOutputItem.data < 0) ? 0 : curOutputItem.data;
					var curConductivity:Number = selectedMaterial.getConductivityForTemp(curTemp);
					var heatLeak:Number;
					if(curConductivity > 0) {
						heatLeak = curConductivity * model.crossSection / model.strutLength;
					} else {
						heatLeak = 0;
					}
					//log.fatal("{0} - curConductivity: " + curConductivity + " model.crossSection: " + model.crossSection + " model.strutLength: " + model.strutLength + " heatLeak: " + heatLeak, getQualifiedClassName(this) + ".fault");
					var curDataShot:DataShotVO = new DataShotVO();
					curDataShot.temperature = curTemp;
					curDataShot.coolingOutputWatts = curCoolWatts;
					curDataShot.heatLeakWatts = heatLeak;
					
					captureData.push(curDataShot);
					
					if(curCoolWatts > highestValue) {
						highestValue = curCoolWatts;
					}
					if(curCoolWatts > highestCooling) {
						highestCooling = curCoolWatts;
					}
					if(heatLeak > highestValue) {
						highestValue = heatLeak;
					}
					if(heatLeak > highestHeat) {
						highestHeat = heatLeak;
					}
				}
				/*
				var stateSnapshot:StateSnapshotVO = new StateSnapshotVO();
				stateSnapshot.captureData = new ArrayCollection(captureData);
				stateSnapshot.highestDataValue = highestValue;
				
				model.stateSnapshot = stateSnapshot;
				*/
				
				var stateSnapshot:StateSnapshotVO = model.stateSnapshot;
				stateSnapshot.cooler = coolerModel.selected;
				stateSnapshot.material = materialModel.selected;
				stateSnapshot.powerFactor = model.powerFactor;
				stateSnapshot.strutLength = model.strutLength;
				stateSnapshot.crossSection = model.crossSection;
				stateSnapshot.captureData = new ArrayCollection(captureData);
				stateSnapshot.highestDataValue = highestValue;
				stateSnapshot.highestCoolingValue = highestCooling;
				stateSnapshot.highestHeatLeakValue = highestHeat;
				if(!stateSnapshot.coolerStroke) {
					var newColorSet:ArrayCollection = graphColorModel.getNextColorSet();
					stateSnapshot.coolerStroke = newColorSet.getItemAt(0) as Stroke;
					stateSnapshot.heatLeakStroke = newColorSet.getItemAt(1) as Stroke;
				}
				model.stateSnapshot = null;
				model.stateSnapshot = stateSnapshot;
				model.snapshotList.itemUpdated(model.stateSnapshot);
				//model.snapshotList.refresh();
			}
			
		}
		
		public function result(event:Object):void {}
		
		public function fault(event:Object):void {}
	}
	
}