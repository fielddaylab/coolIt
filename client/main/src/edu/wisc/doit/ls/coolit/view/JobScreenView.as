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
	public class JobScreenView extends VBox {		
		
		//MXML components
		public var chooseAnotherJob:Button;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var jobModel:JobModel;
		[Bindable] public var coolerModel:CoolerModel;
		[Bindable] public var materialModel:MaterialModel;
		[Bindable] public var stateModel:StateModel;
		
		private var log:ILogger;
		
		private var _currentApplicationState:String;
		
		/*
		 * Constructor
		 */
		public function JobScreenView():void {
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
			chooseAnotherJob.addEventListener(MouseEvent.CLICK, onJobListClick);
		}
		
		private function onJobListClick(event_p:MouseEvent):void {
			var viewJobList:ViewJobListEvent = new ViewJobListEvent();
			viewJobList.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(viewJobList);
		}
		
		/*
		 * Catches mouse click from choose job button
		 *
		 * @param	event_p	MouseEvent
		 */
		private function onStartJobClick(event_p:MouseEvent):void {	
			/*
			var chooseJob:ChooseJobEvent = new ChooseJobEvent();
			chooseJob.modelLocator = model;
			chooseJob.job = model.jobModel.selected;
			CairngormEventDispatcher.getInstance().dispatchEvent(chooseJob);
			*/
		}
		
		[Bindable] public function get currentApplicationState():String {
			return _currentApplicationState;
		}
		public function set currentApplicationState(state_p:String):void {
			if(state_p == StateModel.JOB_SCREEN) {
				//get input power data
				//dispatchEventGetInputPowerData();
			}
			_currentApplicationState = state_p;
		}
		
		public function setArrowIcon(index_p:Number, match_p:Number):Class {
			if(index_p == match_p) {
				return AssetEmbedLocator.openArrow;
			} else {
				return AssetEmbedLocator.closedArrow;
			}
		}
		
		private function dispatchEventGetInputPowerData():void {
			var getInputPowerData:GetInputPowerDataEvent = new GetInputPowerDataEvent();
			getInputPowerData.modelLocator = model;
			getInputPowerData.coolerName = "Small";
			getInputPowerData.powerFactor = 0.62;
			CairngormEventDispatcher.getInstance().dispatchEvent(getInputPowerData);
		}
	}
}