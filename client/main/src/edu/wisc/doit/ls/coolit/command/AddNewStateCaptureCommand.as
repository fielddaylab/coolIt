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
	public class AddNewStateCaptureCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function AddNewStateCaptureCommand() {
			super();
		}
		
		public function execute(event:CairngormEvent):void {
			var addCaptureEvent:AddNewStateCaptureEvent = event as AddNewStateCaptureEvent;
			model = addCaptureEvent.modelLocator;
			var coolerModel:CoolerModel = model.coolerModel;
			var materialModel:MaterialModel = model.materialModel;
			var graphColorModel:GraphColorModel = model.graphColorModel;
			
			var stateSnapshot:StateSnapshotVO = model.stateSnapshot;
			var newColorSet:ArrayCollection = graphColorModel.getNextColorSet();
			
			var newSnapshot:StateSnapshotVO = new StateSnapshotVO(flash.utils.getTimer());
			newSnapshot.cooler = stateSnapshot.cooler;
			newSnapshot.material = stateSnapshot.material;
			newSnapshot.powerFactor = stateSnapshot.powerFactor;
			newSnapshot.strutLength = stateSnapshot.strutLength;
			newSnapshot.crossSection = stateSnapshot.crossSection;
			newSnapshot.captureData = new ArrayCollection(stateSnapshot.captureData.toArray());
			newSnapshot.highestDataValue = stateSnapshot.highestDataValue;
			newSnapshot.highestCoolingValue = newSnapshot.highestCoolingValue;
			newSnapshot.highestHeatLeakValue = newSnapshot.highestHeatLeakValue;
			newSnapshot.coolerStroke = newColorSet.getItemAt(0) as Stroke;
			newSnapshot.heatLeakStroke = newColorSet.getItemAt(1) as Stroke;
			
			model.powerSetting = CoolerModel.OUTPUT_POWER;
			
			model.snapshotList.addItem(newSnapshot);
			model.stateSnapshot = null;
			model.stateSnapshot = newSnapshot;
		}
		
		public function result(event:Object):void {}
		
		public function fault(event:Object):void {}
	}
	
}