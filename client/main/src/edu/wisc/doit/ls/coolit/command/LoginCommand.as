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
	public class LoginCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function LoginCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var loginEvent:LoginEvent = event_p as LoginEvent;
			model = loginEvent.modelLocator;
			
			//model.servicesOut++;
			
			//var delegate:CoolItDelegate = new CoolItDelegate(this);
			//delegate.getProblems();
			var stateModel:StateModel = model.stateModel;
			stateModel.currentState = StateModel.JOB_PICKER;
		}
		
		public function result(event_p:Object):void {
			/*
			var cleanedXML:XML = model.removeNamespaces(event_p.result);			
			model.jobModel = new JobModel(cleanedXML);
			
			model.servicesOut--;
			*/
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}