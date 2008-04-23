package {
	import flash.utils.*;
	import flash.events.*;
	
    import mx.core.Application;
	import mx.events.FlexEvent;
	
	import mx.controls.*;
	import mx.containers.*;
	import mx.collections.ArrayCollection;
	import mx.rpc.soap.mxml.WebService;
	
	import mx.logging.*;
	
	import edu.wisc.doit.ls.logging.LocLogTarget;
    
	import mx.rpc.events.*;
	
	/**
	 *  Handles initializing the application
	 *
	 *  @author Ben Longoria
	 */
    public class MainView extends Application {
		/** Logging category for app */
		public static var APP_CATEGORY:String = "FlexApp";
		
        // Components in MXML
		[Bindable] public var cryoService:WebService;
		[Bindable] public var coolers:ComboBox;
		[Bindable] public var materials:ComboBox;
		public var simResult:Label;
		
		//application classes
		private var logger:LocLogTarget;
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
        public function MainView() {
			super();
			
			//init logging for application
			logger = new LocLogTarget();
			Log.addTarget(logger);
			log = Log.getLogger(APP_CATEGORY);
			log.debug("{0} UI init'd", getQualifiedClassName(this) + ".creationCompleteHandler");
			
            addEventListener(FlexEvent.CREATION_COMPLETE, creationCompleteHandler);
        }
        
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
        private function creationCompleteHandler(event_p:FlexEvent):void {
			//do init actions here
			cryoService.GetCoolers.send();
			cryoService.GetMaterials.send();
        }
		
		public function handleFault(event:FaultEvent):void {
			Alert.show(event.fault.faultDetail, event.fault.faultString);
			log.fatal("{0} faultDetail:" + event.fault.faultDetail + " event.fault.faultString: " + event.fault.faultString, getQualifiedClassName(this) + ".handleFault");
		}
		
		public function handleResult(event:ResultEvent):void {
			//quick and dirty
			if(event.result is ArrayCollection) {
				if(event.result[0].MP) {
					//materials
					materials.dataProvider = event.result;
				} else if(event.result[0].CPM) {
					coolers.dataProvider = event.result;
				}
			} else {
				simResult.text = "Result: " + event.result.toString();
			}
		}
		
    }
}