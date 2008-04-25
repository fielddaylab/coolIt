package edu.wisc.doit.ls.coolit.command {
	import mx.rpc.IResponder;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.business.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	/**
	 * 
	 */
	public class ChooseJobCommand implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function ChooseJobCommand() {}
		
		public function execute(event:CairngormEvent):void {
			var chooseJobEvent:ChooseJobEvent = event as ChooseJobEvent;
			
			model = chooseJobEvent.modelLocator;
			var stateModel:StateModel = model.stateModel;
			stateModel.currentState = StateModel.JOB_SCREEN;
			
			//check coolers and materials
			if(!model.coolerModel) {
				dispatchGetCoolerListEvent();
				dispatchGetMaterialListEvent();
			}
			//var delegate:HelloWorldDelegate = new HelloWorldDelegate(this);
			//delegate.sendThroughHelloWorld(helloWorldEvent.messageContent);
		}
		
		public function result(event:Object):void {		
			var result:Object = event.result;	
			/*
			var model:MessageModelLocator = MessageModelLocator.getInstance();
			var message:MessageVO = model.messageHolder.message;
			message.content = String(result);
			*/
		}
		
		public function fault(event:Object):void {
			//log failure here
		}
		
		private function dispatchGetCoolerListEvent():void {
			var getCoolers:GetCoolerListEvent = new GetCoolerListEvent();
			getCoolers.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(getCoolers);
		}
		
		private function dispatchGetMaterialListEvent():void {
			var getMaterials:GetMaterialListEvent = new GetMaterialListEvent();
			getMaterials.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(getMaterials);
		}
		
	}
	
}