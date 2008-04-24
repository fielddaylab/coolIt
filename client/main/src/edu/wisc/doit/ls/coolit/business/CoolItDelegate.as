package edu.wisc.doit.ls.coolit.business {
	import mx.rpc.IResponder;
	import mx.rpc.AsyncToken;
	import mx.rpc.events.FaultEvent;
	import mx.rpc.events.ResultEvent;
	import mx.rpc.AbstractOperation;
	
	import com.adobe.cairngorm.business.ServiceLocator;
	import com.adobe.cairngorm.model.ModelLocator;
	
	import mx.controls.Alert;
	import flash.utils.describeType;
	import mx.rpc.soap.WebService;
	
	
	/**
	 * 
	 */
	public class CoolItDelegate {
		
		private var responder:IResponder;
		private var service:Object;
		
		public function CoolItDelegate(responder_p:IResponder) {		
			
			service = ServiceLocator.getInstance().getWebService("cryoService");
			responder = responder_p;
		}
		
		/**
		 * Gets a list of jobs (problems)
		 */
		public function getProblems():void {
			var token:AsyncToken = service.GetProblems();
			token.addResponder(responder);
		}
		
	}
	
}