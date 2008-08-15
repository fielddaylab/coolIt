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
	
	import mx.collections.ArrayCollection;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class JobChooserView extends HBox {		
		
		//MXML components
		public var startJob:Button;
		public var jobImage:Image;
		[Bindable] public var jobList:List;
		
		[Bindable] public var requirementsList:ArrayCollection;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var tempRequirements:String = "<br />Temp: --<br />Weight: --<br />Input: --<br />Cost: --<br />";
		
		private var log:ILogger;
		
		
		/*
		 * Constructor
		 */
		public function JobChooserView():void {
			super();
			
			requirementsList = new ArrayCollection();
			
			//set up logging
			log = Log.getLogger(ApplicationClass.APP_CATEGORY);
			log.debug("{0} - View instantiated", getQualifiedClassName(this));
			
			addEventListener(FlexEvent.CREATION_COMPLETE, onComplete);
			//addEventListener(Event.RENDER, onRender);
		}
		
		private function onRender(event_p:Event):void {
			if(model) {
				if(model.jobModel) {
					if(model.jobModel.selected) {
						jobList.selectedItem = model.jobModel.selected;
					}
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
				requirementsList = model.jobModel.selected.requirements;
				buildRequirements();
				
				var selJob:JobVO = model.jobModel.selected;
				var imageList:ArrayCollection = selJob.nestedImageProvider;
				var topImage:String = imageList.getItemAt(0).getItemAt(0) as String;
				
				jobImage.source = topImage;
				//log.fatal("{0} - requirementsList.getItemAt(0).core: " + requirementsList.getItemAt(0).core, getQualifiedClassName(this));
			}
			
			Alert.show("1. Choose a Job\n2. Meet the design requirements to get paid\n3. Solve additional jobs to make more money.","What To Do");
		}
		
		private function onJobListChange(event_p:Event):void {
			model.jobModel.selected = jobList.selectedItem as JobVO;
			requirementsList = model.jobModel.selected.requirements;
			buildRequirements();
			
			var selJob:JobVO = model.jobModel.selected;
			var imageList:ArrayCollection = selJob.nestedImageProvider;
			var topImage:String = imageList.getItemAt(0).getItemAt(0) as String;
			
			jobImage.source = topImage;
			
			//log.fatal("{0} - topImage: " + topImage, getQualifiedClassName(this) + ".onJobListChange");
		}
		
		private function buildRequirements():void {
			/*
			var reqLen:Number = requirementsList.length;
			tempRequirements = "";
			for(var i:Number = 0; i<reqLen; i++) {
				var curReq:RequirementVO = requirementsList.getItemAt(i) as RequirementVO;
				var firstBreak:String = (i == 0) ? "" : "<br />";
				tempRequirements = tempRequirements + firstBreak + "<b>" + curReq.label + "</b> " + curReq.operation + " <b>" + curReq.target + " " + curReq.unit + "</b>";
			}
			*/
			var selJob:JobVO = model.jobModel.selected;
			tempRequirements = selJob.getFormattedRequirements();
		}
		
		/*
		 * Catches mouse click from start job button
		 *
		 * @param	event_p	MouseEvent
		 */
		private function onStartJobClick(event_p:MouseEvent):void {
			
			var chooseJob:ChooseJobEvent = new ChooseJobEvent();
			chooseJob.modelLocator = model;
			chooseJob.job = model.jobModel.selected;
			CairngormEventDispatcher.getInstance().dispatchEvent(chooseJob);
			
			/*
			var enterCutEvent:EnterCutScreenEvent = new EnterCutScreenEvent();
			enterCutEvent.modelLocator = model;
			enterCutEvent.nextStateName = StateModel.JOB_SCREEN;
			enterCutEvent.source = "foo";
			CairngormEventDispatcher.getInstance().dispatchEvent(enterCutEvent);
			*/
		}
	}
}