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
			
			model.servicesOut++;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.getProblems();
		}
		
		public function result(event_p:Object):void {
			var cleanedXML:XML = model.removeNamespaces(event_p.result);			
			model.jobModel = new JobModel(cleanedXML);
			model.jobModel.imageURLBase = model.mediaBase;
			model.jobModel.imageMatrixExtension = model.imageMatrixExtension;
			model.jobModel.videoExtension = model.videoExtension;
			
			model.servicesOut--;
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}