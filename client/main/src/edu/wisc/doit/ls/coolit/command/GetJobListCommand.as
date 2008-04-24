package edu.wisc.doit.ls.coolit.command {
	import flash.utils.*;
	import mx.rpc.IResponder;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.business.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	import edu.wisc.doit.ls.coolit.CommonBase;
	
	/**
	 * 
	 */
	public class GetJobListCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function GetJobListCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var getJobsEvent:GetJobListEvent = event_p as GetJobListEvent;
			model = getJobsEvent.modelLocator;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.getProblems();
		}
		
		public function result(event_p:Object):void {		
			model.jobModel = new JobModel(event_p.result);
			
			//log.fatal("{0} event_p.result.GetProblemsResponse: " + event_p.result.GetProblemsResponse, getQualifiedClassName(this) + ".result");
			
			//log.fatal("{0} event_p.result.GetProblemsResponse: " + event_p.result.GetProblemsResponse, getQualifiedClassName(this) + ".result");
			//log.fatal("{0} event_p.result.GetProblemsResult: " + event_p.result.GetProblemsResult, getQualifiedClassName(this) + ".result");
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}