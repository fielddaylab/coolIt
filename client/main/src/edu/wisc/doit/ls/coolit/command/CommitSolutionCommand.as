package edu.wisc.doit.ls.coolit.command {
	import flash.utils.*;
	import mx.rpc.IResponder;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.*;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.business.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	import edu.wisc.doit.ls.coolit.CommonBase;
	
	import mx.controls.Alert;
	
	/**
	 * 
	 */
	public class CommitSolutionCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function CommitSolutionCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var commitEvent:CommitSolutionEvent = event_p as CommitSolutionEvent;
			model = commitEvent.modelLocator;
			var jobModel:JobModel = model.jobModel;
			var selectedJob:JobVO = jobModel.selected;
			
			var message:String;
			var title:String;
			if(model.isValidSolution) {
				message = "Your solution is valid!!";
				title = "Nice Job!";
				if(!selectedJob.solved) {
					model.bankBalance += jobModel.selected.pay;
					selectedJob.solved = true;
				}
				
			} else {
				message = "Your solution is invalid.";
				title = "Oops!";
			}
			
			//Alert.show(message, title);
			//jobModel.finishCutURL = jobModel.selected.successVideoURL;
			
			dispatchGetFeedback();
		}
		
		public function result(event_p:Object):void {		
			
		}
		
		private function dispatchGetFeedback():void {
			var getFeedbackEvent:GetFeedbackEvent = new GetFeedbackEvent();
			getFeedbackEvent.modelLocator = model;
			getFeedbackEvent.dispatch();
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}