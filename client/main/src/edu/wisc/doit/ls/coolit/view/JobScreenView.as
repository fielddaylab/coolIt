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
	
	import caurina.transitions.Tweener;
	
	import com.benstucki.utilities.IconUtility;
	
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
		public var jobPanel:VBox;
		public var loadingProgress:ChallengeLoader;
		[Bindable] public var jobImage:NestedVideoView;
		public var viewGraph:Button;
		public var viewEquip:Button;
		public var viewDescription:Button;
		public var replayButton:Button;
		public var masterGraph:MasterGraphView;
		[Bindable] public var skipButton:Button;
		
		[Bindable] public var mainWorkArea:TabNavigator;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var jobModel:JobModel;
		[Bindable] public var coolerModel:CoolerModel;
		[Bindable] public var materialModel:MaterialModel;
		[Bindable] public var stateModel:StateModel;
		
		[Bindable] public var jobLoaded:Boolean = false;
		
		[Bindable] public var masterGraphSelected:Boolean = false;
		
		private var log:ILogger;
		
		private var _currentApplicationState:String;
		
		private var hasInit:Boolean = false;
		
		private var highestPNGButton:PNGButtonPane = coolerButton;
		private var lowestPNGButton:PNGButtonPane = supportsButton;
		
		private var cutLoaded:Boolean = false;
		private var imagesLoaded:Boolean = false;
		
		private var startCutTimer:Timer;
		private var goalTimer:Timer;
		
		private var introScreenCutPlaying:Boolean = true;
		private var introReplaying:Boolean = false;
		
		private var goalsShown:Boolean = false;
		private var _finishURL:String;
		
		/*
		 * Constructor
		 */
		public function JobScreenView():void {
			super();
			
			startCutTimer = new Timer(3000, 1);
			startCutTimer.addEventListener(TimerEvent.TIMER, onStartCutTimer);
			
			goalTimer = new Timer(500, 1);
			goalTimer.addEventListener(TimerEvent.TIMER, onGoalDisplayEvent);
			
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
			cutScreenView.addEventListener(CutScreenView.CUT_LOADED, onCutLoaded);
			cutScreenView.addEventListener(CutScreenView.CUT_WAITING, onCutWaiting);
			viewGraph.addEventListener(MouseEvent.CLICK, onViewGraphClick);
			viewEquip.addEventListener(MouseEvent.CLICK, onViewEquipClick);
			viewDescription.addEventListener(MouseEvent.CLICK, onViewDescriptionClick);
			replayButton.addEventListener(MouseEvent.CLICK, onReplayAssembly);
			masterGraph.addEventListener(MasterGraphView.BACK_EVENT, onMasterGraphBackClick);
			masterGraph.addEventListener(MasterGraphView.COOLERS, onMasterGraphCoolerClick);
			masterGraph.addEventListener(MasterGraphView.SUPPORTS, onMasterGraphSupportClick);
			hasInit = true;
			
		}
		
		private function onReplayAssembly(event_p:MouseEvent):void {
			introReplaying = true;
			introScreenCutPlaying = true;
			jobPanel.visible = false;
			cutScreenView.initCutIntro(jobModel.selected.introVideoURL, 0, 0);
			cutScreenView.init();
			cutScreenView.startVideo();
		}
		
		private function onMasterGraphBackClick(event_p:Event):void {
			setMasterGraphActive(false);
		}
		
		private function onViewGraphClick(event_p:MouseEvent):void {
			setMasterGraphActive(true);
		}
		
		private function onViewEquipClick(event_p:MouseEvent):void {
			setMasterGraphActive(false);
		}
		
		private function onViewDescriptionClick(event_p:MouseEvent):void {
			selectDescription();
		}
		
		private function setMasterGraphActive(active_p:Boolean):void {
			masterGraphSelected = active_p;
			if(masterGraphSelected) {
				dispatchGraphMode();
			} else {
				dispatchGeometryMode();
			}
		}
		
		private function onNestedImagesLoaded(event_p:Event):void {
			//call method to turn top image to bitmap data and assign to model's equipmentIcon
			createEquipmentIcon();
			imagesLoaded = true;
			if(cutLoaded) {
				jobLoaded = true;
				startJob();
			}
		}
		
		private function createEquipmentIcon():void {
			var topImage:Image = jobImage.topImage;
			viewEquip.setStyle("icon", IconUtility.getClass(viewEquip, topImage.source as String, 45, 26));
		}
		
		private function onCutLoaded(event_p:Event):void {
			cutLoaded = true;
			if(imagesLoaded && introScreenCutPlaying) {
				jobLoaded = true;
				startJob();
			}
		}
		
		private function startJob():void {
			skipButton.visible = true;
			if(!introReplaying) {
				introReplaying = false;
				loadingProgress.visible = true;
				loadingProgress.alpha = 1;
				Tweener.addTween(loadingProgress, {alpha:0, time:1, delay:1, transition:"easeOutQuart", onComplete:activateJob});
			}
			
		}
		
		private function activateJob():void {
			loadingProgress.visible = false;
			cutScreenView.startVideo();
		}
		
		private function onCutDone(event_p:Event):void {
			jobPanel.visible = true;
			skipButton.visible = false;
			if(!goalsShown) {
				goalsShown = true;
				goalTimer.start();
			}
			
		}
		
		private function onCutWaiting(event_p:Event):void {
			var goalAlert:Alert = Alert.show(jobModel.currentFeedback.text, "Your Result", null, null, onViewedFeedbackClick);
		}
		
		
		private function onViewedFeedbackClick(event_p:CloseEvent):void {
			cutScreenView.finishCut();
		}
		
		private function onGoalDisplayEvent(event_p:TimerEvent):void {
			var goalAlert:Alert = Alert.show("Determine a combination of the cooler and supports to meet the problem requirements, then implement your solution by pressing the red arrow on the bottom-left of the screen.\nTry to minimize the cost of the solution.", "What To Do");
		}
		
		private function onPNGButtonTransparencyOver(event_p:Event):void {
			mainImageHolder.swapChildren(supportsButton, coolerButton);
		}
		
		private function onMasterGraphCoolerClick(event_p:Event):void {
			selectCoolerPicker();
		}
		
		private function onMasterGraphSupportClick(event_p:Event):void {
			selectSupportPicker();
		}
		
		private function onCoolerClick(event_p:Event):void {
			selectCoolerPicker();
		}
		
		private function onSupportsClick(event_p:Event):void {
			selectSupportPicker();
		}
		
		private function selectSupportPicker():void {
			pickerViewstack.selectedIndex = 2;
			supportsButton.selected = true;
			coolerButton.selected = false;
			masterGraph.selectedPickerIndex = 1;
		}
		
		private function selectCoolerPicker():void {
			pickerViewstack.selectedIndex = 1;
			coolerButton.selected = true;
			supportsButton.selected = false;
			masterGraph.selectedPickerIndex = 0;
		}
		
		private function selectDescription():void {
			pickerViewstack.selectedIndex = 0;
			coolerButton.selected = false;
			supportsButton.selected = false;
			masterGraph.selectedPickerIndex = 0;
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
			/*
			introReplaying = false;
			introScreenCutPlaying = false;
			jobPanel.visible = false;
			cutScreenView.initCutOutro(jobModel.finishCutURL, 199, 55);
			
			cutScreenView.init();
			cutScreenView.startVideo();
			*/
		}
		
		[Bindable] public function get finishURL():String {
			return _finishURL;
		}
		public function set finishURL(url_p:String):void {
			_finishURL = url_p;
			if(currentApplicationState == StateModel.JOB_SCREEN && _finishURL) {
				introReplaying = false;
				introScreenCutPlaying = false;
				jobPanel.visible = false;
				cutScreenView.initCutOutro(jobModel.finishCutURL, 199, 55);
				
				cutScreenView.init();
				cutScreenView.startVideo();
			}
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
		
		[Bindable] public function get currentApplicationState():String {
			return _currentApplicationState;
		}
		public function set currentApplicationState(state_p:String):void {
			introReplaying = false;
			if(state_p == StateModel.JOB_SCREEN) {
				jobImage.addEventListener(NestedVideoView.IMAGES_LOADED, onNestedImagesLoaded);
				//set first cooler and material
				coolerPicker.reset();
				strutPicker.reset();
				
				introScreenCutPlaying = true;
				
				//get input power data
				//dispatchEventGetInputPowerData();
				if(hasInit) {
					coolerPicker.dispatchSetCooler();
					strutPicker.dispatchSetStrut();
				}
				
				cutLoaded = false;
				imagesLoaded = false;
				
				cutScreenView.initCutIntro(jobModel.selected.introVideoURL, 0, 0);
				
				loadingProgress.visible = true;
				loadingProgress.alpha = 1;
				
				startCutTimer.reset();
				startCutTimer.start();
				
				 /*
				if(jobLoaded) {
					startJob();
				}
				*/
			} else {
				jobImage.removeEventListener(NestedVideoView.IMAGES_LOADED, onNestedImagesLoaded);
			}
			_currentApplicationState = state_p;
		}
		
		private function onStartCutTimer(event_p:TimerEvent):void {
			cutScreenView.init();
			jobImage.init();
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
		
		private function dispatchGeometryMode():void {
			var setSimModeEvent:SetSimulationModeEvent = new SetSimulationModeEvent();
			setSimModeEvent.modelLocator = model;
			setSimModeEvent.mode = StateModel.GEOMETRY_SIM;
			CairngormEventDispatcher.getInstance().dispatchEvent(setSimModeEvent);
		}
		
		private function dispatchGraphMode():void {
			var setSimModeEvent:SetSimulationModeEvent = new SetSimulationModeEvent();
			setSimModeEvent.modelLocator = model;
			setSimModeEvent.mode = StateModel.GRAPH_SIM;
			CairngormEventDispatcher.getInstance().dispatchEvent(setSimModeEvent);
		}
		
	}
}