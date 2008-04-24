package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.VBox;
	import mx.events.*;
	
	import mx.logging.ILogger;
	import mx.logging.Log;
	
	import flash.events.*;
	import flash.utils.*;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class JobChooserView extends VBox {		
		
		//MXML components
		public var startJob:Button;
		[Bindable] public var jobList:List;
		
		[Bindable]
		public var model:CoolItModelLocator;
		
		private var log:ILogger;
				
		/*
		 * Constructor
		 */
		public function JobChooserView():void {
			super();
			
			//set up logging
			log = Log.getLogger(ApplicationClass.APP_CATEGORY);
			log.debug("{0} - View instantiated", getQualifiedClassName(this));
			
			addEventListener(FlexEvent.CREATION_COMPLETE, onComplete);
		}
		
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
		private function onComplete(event_p:FlexEvent):void {
			log.debug("{0} - creationComplete called", getQualifiedClassName(this) + ".onComplete");
			
			startJob.addEventListener(MouseEvent.CLICK, onStartJobClick);
			jobList.addEventListener(Event.CHANGE, onJobListChange);
		}
		
		private function onJobListChange(event_p:Event):void {
			model.jobModel.selectedJob = jobList.selectedItem as JobVO;
		}
		
		/*
		 * Catches mouse click from start job button
		 *
		 * @param	event_p	MouseEvent
		 */
		private function onStartJobClick(event_p:MouseEvent):void {						
			var chooseJob:ChooseJobEvent = new ChooseJobEvent();
			chooseJob.modelLocator = model;
			chooseJob.job = model.jobModel.selectedJob;
			CairngormEventDispatcher.getInstance().dispatchEvent(chooseJob);
		}
	}
}