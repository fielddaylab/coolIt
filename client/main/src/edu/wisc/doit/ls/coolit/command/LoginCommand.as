package edu.wisc.doit.ls.coolit.command {
	import flash.utils.*;
	import mx.rpc.IResponder;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.CairngormEvent;
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
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
		private var accountId:String;
		private var newLogin:Boolean;
		
		public function LoginCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var loginEvent:LoginEvent = event_p as LoginEvent;
			model = loginEvent.modelLocator;
			accountId = loginEvent.accountId;
			newLogin = loginEvent.newLogin;
			
			model.servicesOut++;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			if(newLogin) {
				delegate.loginNew(accountId);
			} else {
				delegate.login(accountId);
			}
		}
		
		public function result(event_p:Object):void {
			var stateModel:StateModel = model.stateModel;
			
			model.servicesOut--;
			
			//event_p.result is a boolean
			
			if(event_p.result) {
				stateModel.loginState = StateModel.LOGGED_IN;
			} else if(!event_p.result && !newLogin) {
				stateModel.loginState = StateModel.INVALID_LOGIN;
			} else if(!event_p.result && newLogin) {
				//do over again with new login set to false
				var loginEvent:LoginEvent = new LoginEvent();
				loginEvent.modelLocator = model;
				loginEvent.accountId = accountId;
				loginEvent.newLogin = false;
				CairngormEventDispatcher.getInstance().dispatchEvent(loginEvent);
			}
			
			//set the current data with the current material data
			//var cleanedXML:XML = model.removeNamespaces(event_p.result);
			//log.fatal("{0} - typeof(event_p.result): " + typeof(event_p.result), getQualifiedClassName(this) + result);
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