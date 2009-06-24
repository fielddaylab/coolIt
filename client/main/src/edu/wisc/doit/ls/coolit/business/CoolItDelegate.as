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
		 * Sets strut
		 *
		 * @param	name_p			Name of the strut
		 * @param	length_p
		 * @param	crossSection_p
		 */
		public function setStrut(name_p:String, length_p:Number, crossSection_p:Number):void {
			var token:AsyncToken = service.SetStrut(name_p, length_p, crossSection_p);
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
		
		/**
		 * Gets output power data
		 *
		 * @param	name_p			Name of the cooler
		 * @param	powerFactor_p	
		 * @param	temp_p
		 */
		public function getOutputPowerData(name_p:String, powerFactor_p:Number, temp_p:Number):void {
			var token:AsyncToken = service.OutputPower(name_p, temp_p, powerFactor_p);
			token.addResponder(responder);
		}
		
		/**
		 * run simulation
		 */
		public function run():void {
			var token:AsyncToken = service.Run();
			token.addResponder(responder);
		}
		
		/**
		 * Sets problem
		 *
		 * @param	name_p			problem name
		 */
		public function setProblem(name_p:String):void {
			var token:AsyncToken = service.SetProblem(name_p);
			token.addResponder(responder);
		}
		
		/**
		 * Get specific power data
		 */
		public function getSpecificPowerData():void {
			var token:AsyncToken = service.GetSpecificPowerData();
			token.addResponder(responder);
		}
		
		/**
		 * Get feedback
		 */
		public function getFeedback():void {
			var token:AsyncToken = service.GetFeedback();
			token.addResponder(responder);
		}
		
		/**
		 * Login
		 *
		 * @param	email_p	Email address to login with
		 */
		public function login(email_p:String):void {
			var token:AsyncToken = service.Login(email_p);
			token.addResponder(responder);
		}
		
		/**
		 * Login new user
		 *
		 * @param	email_p	Email address to login with
		 */
		public function loginNew(email_p:String):void {
			var token:AsyncToken = service.NewLogin(email_p);
			token.addResponder(responder);
		}
	}
	
}