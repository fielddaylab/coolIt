package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.*;
	import mx.events.*;
	
	import mx.logging.ILogger;
	import mx.logging.Log;
	
	import flash.events.*;
	import flash.utils.*;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	import com.dougmccune.HitTester;
	
	import flash.geom.Point;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class JobScreenView extends VBox {		
		
		//MXML components
		public var chooseAnotherJob:Button;
		public var coolerPicker:CoolerPicker;
		public var strutPicker:StrutPicker;
		public var commitJob:Button;
		public var pickerViewstack:ViewStack;
		public var coolerButton:PNGButtonPane;
		public var supportsButton:PNGButtonPane;
		public var mainImageHolder:Canvas;
		public var cutScreenView:CutScreen;
		public var jobPanel:Panel;
		
		[Bindable] public var mainWorkArea:TabNavigator;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var jobModel:JobModel;
		[Bindable] public var coolerModel:CoolerModel;
		[Bindable] public var materialModel:MaterialModel;
		[Bindable] public var stateModel:StateModel;
		
		private var log:ILogger;
		
		private var _currentApplicationState:String;
		
		private var hasInit:Boolean = false;
		
		private var highestPNGButton:PNGButtonPane = coolerButton;
		private var lowestPNGButton:PNGButtonPane = supportsButton;
		
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
			//mainWorkArea.addEventListener(IndexChangedEvent.CHANGE, onMainWorkAreaChange);
			chooseAnotherJob.addEventListener(MouseEvent.CLICK, onJobListClick);
			commitJob.addEventListener(MouseEvent.CLICK, onCommitClick);
			coolerButton.addEventListener(PNGButtonPaneView.CLICK_HIT_EVENT, onCoolerClick);
			coolerButton.addEventListener(PNGButtonPaneView.MOUSE_OVER_TRANSPARENT, onPNGButtonTransparencyOver);
			supportsButton.addEventListener(PNGButtonPaneView.CLICK_HIT_EVENT, onSupportsClick);
			supportsButton.addEventListener(PNGButtonPaneView.MOUSE_OVER_TRANSPARENT, onPNGButtonTransparencyOver);
			cutScreenView.addEventListener(CutScreenView.CUT_DONE, onCutDone);
			hasInit = true;
		}
		
		private function onCutDone(event_p:Event):void {
			jobPanel.visible = true;
		}
		
		private function onPNGButtonTransparencyOver(event_p:Event):void {
			mainImageHolder.swapChildren(supportsButton, coolerButton);
		}
		
		private function onCoolerClick(event_p:Event):void {
			pickerViewstack.selectedIndex = 1;
			coolerButton.selected = true;
			supportsButton.selected = false;
		}
		
		private function onSupportsClick(event_p:Event):void {
			pickerViewstack.selectedIndex = 2;
			supportsButton.selected = true;
			coolerButton.selected = false;
		}
		
		private function onMainWorkAreaChange(event_p:IndexChangedEvent):void {
			if(event_p.newIndex == 0) {
				dispatchChangeWorkAreaState(StateModel.COMPONENT_STATE);
			} else {
				dispatchChangeWorkAreaState(StateModel.SKETCH_STATE);
			}
		}
		
		private function onCommitClick(event_p:MouseEvent):void {
			var commitSolutionEvent:CommitSolutionEvent = new CommitSolutionEvent();
			commitSolutionEvent.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(commitSolutionEvent);
		}
		
		private function onJobListClick(event_p:MouseEvent):void {
			pickerViewstack.selectedIndex = 0;
			supportsButton.selected = false;
			coolerButton.selected = false;
			jobPanel.visible = false;
			
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
				if(hasInit) {
					coolerPicker.dispatchSetCooler();
					strutPicker.dispatchSetStrut();
				}
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
		
		private function dispatchChangeWorkAreaState(stateName_p:String):void {
			var changeWorkArea:ChangeWorkAreaStateEvent = new ChangeWorkAreaStateEvent();
			changeWorkArea.modelLocator = model;
			changeWorkArea.stateName = stateName_p;
			CairngormEventDispatcher.getInstance().dispatchEvent(changeWorkArea);
		}
		
	}
}