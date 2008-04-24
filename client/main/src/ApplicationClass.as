package {
	import flash.utils.*;
	import flash.events.*;
	
    import mx.core.Application;
	import mx.events.FlexEvent;
	
	import mx.controls.*;
	import mx.containers.*;
	
	import mx.logging.*;
	
	import edu.wisc.doit.ls.logging.LocLogTarget;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.view.*;
	import edu.wisc.doit.ls.coolit.control.*;
	import edu.wisc.doit.ls.coolit.business.*;
	import edu.wisc.doit.ls.coolit.event.*;
    
	/**
	 *  Handles initializing the application
	 *
	 *  @author Ben Longoria
	 */
    public class ApplicationClass extends Application {
		/** Logging category for app */
		public static var APP_CATEGORY:String = "CoolItApp";
		
		[Bindable]
		public var model:CoolItModelLocator = CoolItModelLocator.getInstance();
		public var controller:CoolItController;
		private var services:Services;
		
		private var logger:LocLogTarget;
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
        public function ApplicationClass() {
			super();
			
			//init logging for application
			logger = new LocLogTarget();
			Log.addTarget(logger);
			log = Log.getLogger(APP_CATEGORY);
			log.debug("{0} UI init'd", getQualifiedClassName(this) + ".onComplete");
			
			controller = new CoolItController();
			services = new Services();
			
            addEventListener(FlexEvent.CREATION_COMPLETE, onComplete);
        }
        
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
        private function onComplete(event_p:FlexEvent):void {
			var getJobListEvent:GetJobListEvent = new GetJobListEvent();
			getJobListEvent.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(getJobListEvent);
        }
		
		
    }
}