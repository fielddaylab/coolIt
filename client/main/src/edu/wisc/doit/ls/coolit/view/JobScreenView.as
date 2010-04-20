package edu.wisc.doit.ls.coolit.view
{
    import caurina.transitions.*;
    
    import com.adobe.cairngorm.control.*;
    import com.benstucki.utilities.*;
    
    import edu.wisc.doit.ls.coolit.event.*;
    import edu.wisc.doit.ls.coolit.model.*;
    import edu.wisc.doit.ls.coolit.vo.*;
    
    import flash.events.*;
    import flash.utils.*;
    
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.DragSource;
    import mx.events.*;
    import mx.logging.ILogger;
    import mx.logging.Log;
    import mx.managers.DragManager;

	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class JobScreenView extends VBox 
	{
		// Define static constant for event type.
		public static const RESIZE_CLICK:String = "resizeClick";

        // Variables used to hold the mouse pointer's location in the title bar.
        // Since the mouse pointer can be anywhere in the title bar, you have to 
        // compensate for it when you drop the panel. 
        public var xOff:Number;
        public var yOff:Number;
 
		// Draggable Panel component defs
		private var rbComp:RubberBandComp;
		public var workCanvas:Canvas;

		// Save panel being resized.
		protected var resizingPanel:Panel;
		// Global coordinates of lower left corner of panel.
		protected var initX:Number;
		protected var initY:Number;

		//MXML components
		public var chooseAnotherJob:Button;
		public var coolerPicker:CoolerPicker;
		public var strutPicker:StrutPicker;
		public var commitJob:Button;
		public var pickerViewstack:ViewStack;
		public var coolerBtn:Button;
		public var supportsBtn:Button;
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
		
		public var bodyMeterButton:LinkButton;
		public var strutMeterButton:LinkButton;
		public var otherMeterButton:LinkButton;
		
		public var powerMeter:MiniMeter;
		public var strengthMeter:MiniMeter;
		public var tempMeter:MiniMeter;
		public var costMeter:MiniMeter;
		
		// meter components
		public var meterPanel:DragPanel;
		public var meterStrutPanel:DragPanel;
		public var meterOtherPanel:DragPanel;

		[Bindable] public var skipButton:Button;
		
		[Bindable] public var mainWorkArea:TabNavigator;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var jobModel:JobModel;
		[Bindable] public var coolerModel:CoolerModel;
		[Bindable] public var materialModel:MaterialModel;
		[Bindable] public var stateModel:StateModel;
		
		[Bindable] public var jobLoaded:Boolean = false;
		
		[Bindable] public var masterGraphSelected:Boolean = false;
		
		[Bindable] public var draggableMeterWidthTemp:Number = 95;
		[Bindable] public var draggableMeterWidthCost:Number = 95;
		[Bindable] public var draggableMeterWidthStr:Number = 82;
		[Bindable] public var draggableMeterWidthPower:Number = 90;
		
		private var log:ILogger;
		
		private var _currentApplicationState:String;
		
		private var hasInit:Boolean = false;
		
		private var cutLoaded:Boolean = false;
		private var imagesLoaded:Boolean = false;
		
		private var startCutTimer:Timer;
		private var goalTimer:Timer;
		
		private var introScreenCutPlaying:Boolean = true;
		private var introReplaying:Boolean = false;
		
		private var goalsShown:Boolean = false;
		private var _finishURL:String;
		
		private var needsGraphReset:Boolean = true;
		
		/*
		 * Constructor
		 */
		public function JobScreenView():void
		{
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
		
		private function openMeter(event:Event):void
		{
			var tempTarget:LinkButton;
			tempTarget = LinkButton(event.target);
			if (tempTarget.id == "bodyMeterButton")
			{
				meterPanel.visible = true;
				bodyMeterButton.removeEventListener(MouseEvent.CLICK,openMeter);
				bodyMeterButton.addEventListener(MouseEvent.CLICK,closeMeter);							
			}
			else if (tempTarget.id == "strutMeterButton")
			{
				meterStrutPanel.visible = true;
				strutMeterButton.removeEventListener(MouseEvent.CLICK,openMeter);
				strutMeterButton.addEventListener(MouseEvent.CLICK,closeMeter);
			}
			else if (tempTarget.id == "otherMeterButton")
			{
				meterOtherPanel.visible = true;
				otherMeterButton.removeEventListener(MouseEvent.CLICK,openMeter);
				otherMeterButton.addEventListener(MouseEvent.CLICK,closeMeter);							
			}
		}
		
		private function closeMeter(event:Event):void
		{
			var tempTarget:LinkButton;
			tempTarget = LinkButton(event.target);
			if (tempTarget.id == "bodyMeterButton")
			{
				meterPanel.visible = false;
				bodyMeterButton.removeEventListener(MouseEvent.CLICK,closeMeter);
				bodyMeterButton.addEventListener(MouseEvent.CLICK,openMeter);
			}
			else if (tempTarget.id == "strutMeterButton")
			{
				meterStrutPanel.visible = false;
				strutMeterButton.removeEventListener(MouseEvent.CLICK,closeMeter);
				strutMeterButton.addEventListener(MouseEvent.CLICK,openMeter);
			}
			else if (tempTarget.id == "otherMeterButton")
			{
				meterOtherPanel.visible = false;
				otherMeterButton.removeEventListener(MouseEvent.CLICK,closeMeter);
				otherMeterButton.addEventListener(MouseEvent.CLICK,openMeter);
			}
		}
		
		
/*		private function openBodyMeter(event:Event):void
		{
			// show meter and swap listeners
			meterPanel.visible = true;
		}
		
		private function closeBodyMeter(event:Event):void
		{
			// hide meter and swap listeners
			meterPanel.visible = false;
			bodyMeterButton.removeEventListener(MouseEvent.CLICK,closeBodyMeter);
			bodyMeterButton.addEventListener(MouseEvent.CLICK,openBodyMeter);
		}
		
		private function openStrutMeter(event:Event):void
		{
			// show meter and swap listeners
			meterStrutPanel.visible = true;
			strutMeterButton.removeEventListener(MouseEvent.CLICK,openStrutMeter);
			strutMeterButton.addEventListener(MouseEvent.CLICK,closeStrutMeter);			
		}
		
		private function closeStrutMeter(event:Event):void
		{
			// hide meter and swap listeners
			meterStrutPanel.visible = false;
			strutMeterButton.removeEventListener(MouseEvent.CLICK,closeStrutMeter);
			strutMeterButton.addEventListener(MouseEvent.CLICK,openStrutMeter);
		}
		
		private function openOtherMeter(event:Event):void
		{
			// show meter and swap listeners
		}
		
		private function closeOtherMeter(event:Event):void
		{
			// hide meter and swap listeners
			meterOtherPanel.visible = false;
			otherMeterButton.removeEventListener(MouseEvent.CLICK,closeOtherMeter);
			otherMeterButton.addEventListener(MouseEvent.CLICK,openOtherMeter);
		}
		
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
		private function onComplete(event_p:FlexEvent):void
		{
			log.debug("{0} - creationComplete called", getQualifiedClassName(this) + ".onComplete");
			//mainWorkArea.addEventListener(IndexChangedEvent.CHANGE, onMainWorkAreaChange);
			chooseAnotherJob.addEventListener(MouseEvent.CLICK, onJobListClick);
			commitJob.addEventListener(MouseEvent.CLICK, onCommitClick);
			coolerBtn.addEventListener(MouseEvent.CLICK, onCoolerClick);
			supportsBtn.addEventListener(MouseEvent.CLICK, onSupportsClick);
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
			
			// set up button properties
			bodyMeterButton.addEventListener(MouseEvent.CLICK, openMeter);
            bodyMeterButton.setStyle('icon', AssetEmbedLocator.infoIcon);
			strutMeterButton.addEventListener(MouseEvent.CLICK, openMeter);
            strutMeterButton.setStyle('icon', AssetEmbedLocator.infoIcon);
			otherMeterButton.addEventListener(MouseEvent.CLICK, openMeter);
            otherMeterButton.setStyle('icon', AssetEmbedLocator.infoIcon);

            // get breakpoints for success/failure
            var testReq:RequirementVO = jobModel.selected.getRequirementByLabel("TEMP");
//Alert.show("label: " + testReq.label + ", op: " + testReq.operation + ", val: " + testReq.target.toString());
            tempMeter.valuePassesPoint = testReq.target;
            
            // set up minimeters
            tempMeter.initMeter();
            costMeter.initMeter();
            strengthMeter.initMeter();
            powerMeter.initMeter();
		}
		
		
		
		/*********************** DRAGGABLE PANEL FUNCTIONS ******************/
		
	    // Function called by the canvas dragEnter event; enables dropping
        public function doDragEnter(event:DragEvent):void 
        {
            DragManager.acceptDragDrop(Canvas(event.target));
        }

        // Drag initiator event handler for
        // the title bar's mouseMove event.
        private function tbMouseMoveHandler(event:MouseEvent):void 
        {
            var dragInitiator:Panel=Panel(event.currentTarget.parent);
            var ds:DragSource = new DragSource();
            ds.addData(event.currentTarget.parent, 'panel'); 
            
    	    // Update the xOff and yOff variables to show the
        	// current mouse location in the Panel.  
            xOff = event.currentTarget.mouseX;
            yOff = event.currentTarget.mouseY;
            
            // Initiate d&d. 
            DragManager.doDrag(dragInitiator, ds, event);                    
        }            

        // Function called by the Canvas dragDrop event; 
        // Sets the panel's drop position.
        public function doDragDrop(event:DragEvent):void 
        {
			// Compensate for the mouse pointer's location in the title bar.
			var tempX:int = event.currentTarget.mouseX - xOff;
			event.dragInitiator.x = tempX;
			
			var tempY:int = event.currentTarget.mouseY - yOff;
			event.dragInitiator.y = tempY;
			
			// Put the dragged panel on top of all other components.
			workCanvas.setChildIndex(Panel(event.dragInitiator), workCanvas.numChildren-1);			
        }

		// Resize area of panel clicked.
		protected function resizeHandler(event:MouseEvent):void
		{
			resizingPanel = Panel(event.target);
			initX = event.localX;
			initY = event.localY;
			
			// Place the rubber band over the panel. 
			rbComp.x = event.target.x;
			rbComp.y = event.target.y;
			rbComp.height = event.target.height;
			rbComp.width = event.target.width;
			
			// Make sure rubber band is on top of all other components.
			workCanvas.setChildIndex(rbComp, workCanvas.numChildren-1);
			rbComp.visible=true;
			
			// Add event handlers so that the SystemManager handles 
			// the mouseMove and mouseUp events. 
			// Set useCapure flag to true to handle these events 
			// during the capture phase so no other component tries to handle them.
			systemManager.addEventListener(MouseEvent.MOUSE_MOVE, mouseMoveHandler, true);
			systemManager.addEventListener(MouseEvent.MOUSE_UP, mouseUpHandler, true);
		}
		
		// Resizes the rubber band as the user moves the cursor 
		// with the mouse key down.
		protected function mouseMoveHandler(event:MouseEvent):void
		{
				event.stopImmediatePropagation();		
					
				rbComp.height = rbComp.height + event.stageY - initY;  
				rbComp.width = rbComp.width + event.stageX - initX;
				
				initX = event.stageX;
				initY = event.stageY;						
		}
		
		// Sizes the panel to the size of the rubber band when the 
		// user releases the mouse key. 
		// Also removes the event handlers from the SystemManager.
		protected function mouseUpHandler(event:MouseEvent):void
		{
			event.stopImmediatePropagation();		

			// Use a minimum panel size of 150 x 50.
			if (rbComp.height <= 50)
			{
				resizingPanel.height = 50;  
			}
			else
			{
				resizingPanel.height = rbComp.height;  				
			}				
			
			if (rbComp.width <= 150)
			{
				resizingPanel.width = 150;				
			}
			else
			{
				resizingPanel.width = rbComp.width;				
			}				

			// Put the resized panel on top of all other components.
			workCanvas.setChildIndex(resizingPanel, workCanvas.numChildren-1);

			// Hide the rubber band until next time.
			rbComp.x = 0;
			rbComp.y = 0;
			rbComp.height = 0;
			rbComp.width = 0;
			rbComp.visible = false;
			
			systemManager.removeEventListener(MouseEvent.MOUSE_MOVE, mouseMoveHandler, true);
			systemManager.removeEventListener(MouseEvent.MOUSE_UP, mouseUpHandler, true	);
		}
		
		/************************** END DRAGGABLE PANEL CODE ***************************/
		
		
		
		
		public function onDragPanelComplete(event):void
		{
			event.currentTarget.myTitleBar.addEventListener(MouseEvent.MOUSE_DOWN, tbMouseMoveHandler);
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
			if(needsGraphReset) {
				needsGraphReset = false;
				masterGraph.reset();
			}
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
		
		//private function onPNGButtonTransparencyOver(event_p:Event):void {
		//	mainImageHolder.swapChildren(supportsButton, coolerButton);
		//}
		
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
			//supportsButton.selected = true;
			//coolerButton.selected = false;
			masterGraph.selectedPickerIndex = 1;
		}
		
		private function selectCoolerPicker():void {
			pickerViewstack.selectedIndex = 1;
			//coolerButton.selected = true;
			//supportsButton.selected = false;
			masterGraph.selectedPickerIndex = 0;
		}
		
		private function selectDescription():void {
			pickerViewstack.selectedIndex = 0;
			//coolerButton.selected = false;
			//supportsButton.selected = false;
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
			//supportsButton.selected = false;
			//coolerButton.selected = false;
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
				setMasterGraphActive(false);
				needsGraphReset = true;
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
		
		public function normaliseMeterValue(value:Number,valueMax:Number,normaliseToMax:Number):Number
		{
			// change the scale of any number to any other scale via cross-multiplication
			var answer:Number = 0;
			answer = (value*normaliseToMax)/valueMax;
			return answer;
		}
	}
}