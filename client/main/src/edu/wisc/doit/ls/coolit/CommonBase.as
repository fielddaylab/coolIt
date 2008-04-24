package edu.wisc.doit.ls.coolit {
	
	import mx.logging.ILogger;
	import mx.logging.Log;
	import flash.utils.*;
	
	/**
	 *  Stores common functionality needed for project like logging, etc.
	 *
	 *  @author Ben Longoria
	 */
	public class CommonBase {
		
		protected var log:ILogger;
		
		public function CommonBase() {
			log = Log.getLogger(ApplicationClass.APP_CATEGORY);
		}
		
		
		
	}
	
}