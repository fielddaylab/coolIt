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
		
		/**
		 * Gets a list of coolers
		 */
		public function getCoolers():void {
			var token:AsyncToken = service.GetCoolers();
			token.addResponder(responder);
		}
		
		/**
		 * Gets a list of materials
		 */
		public function getMaterials():void {
			var token:AsyncToken = service.GetMaterials();
			token.addResponder(responder);
		}
		
		/**
		 * Sets cooler
		 *
		 * @param	name_p			Name of the cooler
		 * @param	powerFactor_p	
		 */
		public function setCooler(name_p:String, powerFactor_p:Number):void {
			var token:AsyncToken = service.SetCooler(name_p, powerFactor_p);
			token.addResponder(responder);
		}
		
		/**
		 * Gets input power data
		 *
		 * @param	name_p			Name of the cooler
		 * @param	powerFactor_p	
		 * @param	temp_p
		 */
		public function getInputPowerData(name_p:String, powerFactor_p:Number, temp_p:Number):void {
			var token:AsyncToken = service.InputPower(name_p, temp_p, powerFactor_p);
			token.addResponder(responder);
		}
		
	}
	
}