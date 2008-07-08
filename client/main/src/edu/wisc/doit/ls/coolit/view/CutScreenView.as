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
	
	import caurina.transitions.Tweener;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class CutScreenView extends VBox {
		public static var CUT_LOADED:String = "edu.wisc.doit.ls.coolit.view.curLoaded";
		public static var CUT_DONE:String = "edu.wisc.doit.ls.coolit.view.cutDone";
		
		//MXML components
		public var cutScreenMovie:VideoDisplay;
		public var shiftSpacerWidth:Spacer;
		public var shiftSpacerHeight:Spacer;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var heightPushAmount:Number = 0;
		[Bindable] public var widthPushAmount:Number = 0;
		
		private var _currentApplicationState:String;
		
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function CutScreenView():void {
			super();
			
			//set up logging
			log = Log.getLogger(ApplicationClass.APP_CATEGORY);
			log.debug("{0} - View instantiated", getQualifiedClassName(this));
			
			addEventListener(FlexEvent.CREATION_COMPLETE, onComplete);
		}
		
		[Bindable] public function get currentApplicationState():String {
			return _currentApplicationState;
		}
		public function set currentApplicationState(state_p:String):void {
			shiftSpacerWidth.width = 0;
			shiftSpacerHeight.height = 0;
			
			if(state_p != StateModel.JOB_SCREEN) {
				cutScreenMovie.visible = false;
				cutScreenMovie.stop();
			} else {
				visible = true;
				alpha = 1;
			}
		}
		
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
		private function onComplete(event_p:FlexEvent):void {
			log.debug("{0} - creationComplete called", getQualifiedClassName(this) + ".onComplete");
			cutScreenMovie.addEventListener(VideoEvent.COMPLETE, onVideoFinished);
			cutScreenMovie.addEventListener(VideoEvent.READY, onVideoReady);
		}
		
		public function startVideo():void {
			cutScreenMovie.visible = true;
			cutScreenMovie.play();
		}
		
		private function onVideoReady(event_p:VideoEvent):void {
			var cutLoadedEvent:Event = new Event(CUT_LOADED);
			dispatchEvent(cutLoadedEvent);
		}
		
		private function onVideoFinished(event_p:VideoEvent):void {
			//leaveCut();
			Tweener.addTween(shiftSpacerWidth, {width:widthPushAmount, time:1, transition:"easeOutQuart"});
			Tweener.addTween(shiftSpacerHeight, {height:heightPushAmount, time:1, transition:"easeOutQuart", onComplete:dispatchCutDoneEvent});
			Tweener.addTween(this, {alpha:0, time:1, delay:1, transition:"easeOutQuart", onComplete:flipOff});
		}
		
		private function dispatchCutDoneEvent():void {
			var curDoneEvent:Event = new Event(CUT_DONE);
			dispatchEvent(curDoneEvent);
		}
		
		private function flipOff():void {
			visible = false;
		}
		
		private function leaveCut():void {
			var leaveCutEvent:LeaveCutScreenEvent = new LeaveCutScreenEvent();
			leaveCutEvent.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(leaveCutEvent);
		}
	}
}