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
	
	/**
	 * 
	 */
	public class LeaveCutScreenCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function LeaveCutScreenCommand() {
			super();
		}
		
		public function execute(event:CairngormEvent):void {
			var leaveCutEvent:LeaveCutScreenEvent = event as LeaveCutScreenEvent;
			model = leaveCutEvent.modelLocator;
			var stateModel:StateModel = model.stateModel;
			
			switch (stateModel.afterCutState) {
				case StateModel.JOB_SCREEN:
					dispatchChooseJobEvent();
					break;
				default:
					stateModel.currentState = stateModel.afterCutState;
					break;
			}
			
		}
		
		public function result(event:Object):void {}
		
		public function fault(event:Object):void {}
		
		private function dispatchChooseJobEvent():void {
			var chooseJob:ChooseJobEvent = new ChooseJobEvent();
			chooseJob.modelLocator = model;
			chooseJob.job = model.jobModel.selected;
			CairngormEventDispatcher.getInstance().dispatchEvent(chooseJob);
		}
	}
	
}