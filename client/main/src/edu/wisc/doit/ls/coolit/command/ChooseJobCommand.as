package edu.wisc.doit.ls.coolit.command {
	import mx.rpc.IResponder;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.business.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	
	/**
	 * 
	 */
	public class ChooseJobCommand implements ICommand {
		
		private var model:CoolItModelLocator;
		private var jobVO:JobVO;
		
		public function ChooseJobCommand() {}
		
		public function execute(event:CairngormEvent):void {
			var chooseJobEvent:ChooseJobEvent = event as ChooseJobEvent;
			jobVO = chooseJobEvent.job;
			model = chooseJobEvent.modelLocator;
			var stateModel:StateModel = model.stateModel;
			var materialModel:MaterialModel = model.materialModel;
			
			stateModel.currentState = StateModel.JOB_SCREEN;
			
			materialModel.lengthMin = jobVO.strutLengthMin;
			materialModel.lengthMax = jobVO.strutLengthMax;
			materialModel.crossSectionMax = jobVO.strutCrossSectionMax;
			
			dispatchSetProblem(jobVO.name);
		}
		
		private function dispatchSetProblem(name_p:String):void {
			var setProblemEvent:SetProblemEvent = new SetProblemEvent();
			setProblemEvent.modelLocator = model;
			setProblemEvent.problemName = name_p;
			CairngormEventDispatcher.getInstance().dispatchEvent(setProblemEvent);
		}
		
	}
	
}