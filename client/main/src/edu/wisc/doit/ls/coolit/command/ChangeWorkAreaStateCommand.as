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
	public class ChangeWorkAreaStateCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function ChangeWorkAreaStateCommand() {
			super();
		}
		
		public function execute(event:CairngormEvent):void {
			var changeWorkStateEvent:ChangeWorkAreaStateEvent = event as ChangeWorkAreaStateEvent;
			model = changeWorkStateEvent.modelLocator;
			var stateModel:StateModel = model.stateModel;
			
			stateModel.workAreaState = changeWorkStateEvent.stateName;
			
		}
		
		public function result(event:Object):void {}
		
		public function fault(event:Object):void {}
	}
	
}