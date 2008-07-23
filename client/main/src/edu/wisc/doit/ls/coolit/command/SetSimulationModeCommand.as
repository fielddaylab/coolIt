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
	
	/**
	 * 
	 */
	public class SetSimulationModeCommand extends CommonBase implements ICommand {
		
		private var model:CoolItModelLocator;
		
		public function SetSimulationModeCommand() {
			super();
		}
		
		public function execute(event:CairngormEvent):void {
			var setSimModeEvent:SetSimulationModeEvent = event as SetSimulationModeEvent;
			model = setSimModeEvent.modelLocator;
			var stateModel:StateModel = model.stateModel;
			stateModel.simulationMode = setSimModeEvent.mode;
			
			if(setSimModeEvent.mode == StateModel.GRAPH_SIM) {
				//dispatch update capture event
				dispatchUpdateStateCapture();
			}
		}
		
		public function dispatchUpdateStateCapture():void {
			var updateCapture:UpdateStateCaptureEvent = new UpdateStateCaptureEvent();
			updateCapture.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(updateCapture);
		}

	}
	
}