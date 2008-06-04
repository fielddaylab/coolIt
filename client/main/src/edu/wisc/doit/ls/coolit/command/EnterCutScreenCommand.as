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
	public class EnterCutScreenCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function EnterCutScreenCommand() {
			super();
		}
		
		public function execute(event:CairngormEvent):void {
			var enterCutEvent:EnterCutScreenEvent = event as EnterCutScreenEvent;
			model = enterCutEvent.modelLocator;
			var stateModel:StateModel = model.stateModel;
			
			stateModel.afterCutState = enterCutEvent.nextStateName;
			stateModel.currentCutSource = enterCutEvent.source;
			
			stateModel.currentState = StateModel.CUT_SCREEN_STATE;
			//stateModel.workAreaState = changeWorkStateEvent.stateName;
			
		}
		
		public function result(event:Object):void {}
		
		public function fault(event:Object):void {}
	}
	
}