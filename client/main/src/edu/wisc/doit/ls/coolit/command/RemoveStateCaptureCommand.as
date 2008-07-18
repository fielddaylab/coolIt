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
	public class RemoveStateCaptureCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function RemoveStateCaptureCommand() {
			super();
		}
		
		public function execute(event:CairngormEvent):void {
			var removeCaptureEvent:RemoveStateCaptureEvent = event as RemoveStateCaptureEvent;
			model = removeCaptureEvent.modelLocator;
			var coolerModel:CoolerModel = model.coolerModel;
			var materialModel:MaterialModel = model.materialModel;
			var graphColorModel:GraphColorModel = model.graphColorModel;
			
			var stateSnapshot:StateSnapshotVO = model.stateSnapshot;
			var snapList:ArrayCollection = model.snapshotList;
			var snapLen:Number = snapList.length;
			//find matching in list, then remove, and set first as selected via event
			for(var i:Number = 0; i<snapLen; i++) {
				var curSnap:StateSnapshotVO = snapList.getItemAt(i) as StateSnapshotVO;
				if(curSnap == stateSnapshot) {
					snapList.removeItemAt(i);
					break;
				}
			}
			var snapshotToSelect:StateSnapshotVO = snapList.getItemAt(0) as StateSnapshotVO;
			dispatchRemoveStateCapture(snapshotToSelect);
		}
		
		public function result(event:Object):void {}
		
		public function fault(event:Object):void {}
		
		private function dispatchRemoveStateCapture(capture_p:StateSnapshotVO):void {
			var selectCapture:SelectStateCaptureEvent = new SelectStateCaptureEvent();
			selectCapture.modelLocator = model;
			selectCapture.stateSnapshot = capture_p;
			CairngormEventDispatcher.getInstance().dispatchEvent(selectCapture);
		}
	}
	
}