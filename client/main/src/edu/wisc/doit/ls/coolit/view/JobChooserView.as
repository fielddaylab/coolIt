package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.HBox;
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
	public class JobChooserView extends HBox {		
		
		//MXML components
		public var startJob:Button;
		[Bindable] public var jobList:DataGrid;
		
		[Bindable]
		public var model:CoolItModelLocator;
		public var tempRequirements:String = "<br />Temp: --<br />Weight: --<br />Input: --<br />Cost: --<br />";
		
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
			addEventListener(Event.RENDER, onRender);
		}
		
		private function onRender(event_p:Event):void {
			if(model) {
				if(model.jobModel.selected) {
					jobList.selectedItem = model.jobModel.selected;
				}
			}
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
			
			var getPowerData:GetSpecificPowerDataEvent = new GetSpecificPowerDataEvent();
			getPowerData.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(getPowerData);
			
			if(model.jobModel.selected) {
				jobList.selectedItem = model.jobModel.selected;
			}
		}
		
		private function onJobListChange(event_p:Event):void {
			model.jobModel.selected = jobList.selectedItem as JobVO;
		}
		
		/*
		 * Catches mouse click from start job button
		 *
		 * @param	event_p	MouseEvent
		 */
		private function onStartJobClick(event_p:MouseEvent):void {						
			var enterCutEvent:EnterCutScreenEvent = new EnterCutScreenEvent();
			enterCutEvent.modelLocator = model;
			enterCutEvent.nextStateName = StateModel.JOB_SCREEN;
			enterCutEvent.source = "foo";
			CairngormEventDispatcher.getInstance().dispatchEvent(enterCutEvent);
		}
	}
}