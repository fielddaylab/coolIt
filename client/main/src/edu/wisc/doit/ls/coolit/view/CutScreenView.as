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
	import flash.media.SoundMixer;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class CutScreenView extends VBox
	{
		public static var CUT_LOADED:String = "edu.wisc.doit.ls.coolit.view.curLoaded";
		public static var CUT_DONE:String = "edu.wisc.doit.ls.coolit.view.cutDone";
		public static var CUT_WAITING:String = "edu.wisc.doit.ls.coolit.view.cutWaiting";
		public static var INTRO:String = "edu.wisc.doit.ls.coolit.view.intro";
		public static var OUTRO:String = "edu.wisc.doit.ls.coolit.view.outro";
		
		//MXML components
		public var videoHolder:Box;
		public var cutScreenMovie:VideoDisplay;
		public var shiftSpacerWidth:Spacer;
		public var shiftSpacerHeight:Spacer;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var heightPushAmount:Number = 0;
		[Bindable] public var widthPushAmount:Number = 0;
		[Bindable] public var mediaWidth:Number = 457;
		[Bindable] public var mediaHeight:Number = 280;
		[Bindable] public var mediaURL:String;
		
		private var _currentApplicationState:String;
		
		private var currentlyPlaying:String = INTRO;
		
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
			if(state_p != StateModel.JOB_SCREEN) {
				removeVideo();
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
			
		}
		
		public function initCutIntro(mediaURL_p:String, spacerWidth_p:Number, spacerHeight_p:Number):void {
			currentlyPlaying = INTRO;
			setSpacerSize(0, 0);
			reset();
			mediaURL = mediaURL_p;
			visible = true;
			alpha = 1;
		}
		
		public function initCutOutro(mediaURL_p:String, spacerWidth_p:Number, spacerHeight_p:Number):void {
			currentlyPlaying = OUTRO;
			visible = true;
			alpha = 0;
			setSpacerSize(spacerWidth_p, spacerHeight_p);
			reset();
			mediaURL = mediaURL_p;
		}
		
		public function setSpacerSize(width_p:Number, height_p:Number):void {
			shiftSpacerWidth.width = width_p;
			shiftSpacerHeight.height = height_p;
		}
		
		public function reset():void {
			removeVideo();
		}
		
		public function init():void {
			removeVideo();
			//cutScreenMovie.source = mediaURL;
			cutScreenMovie = new VideoDisplay();
			cutScreenMovie.autoPlay = false;
			cutScreenMovie.autoRewind = false;
			cutScreenMovie.percentWidth = 100;
			cutScreenMovie.percentHeight = 100;
			cutScreenMovie.addEventListener(VideoEvent.COMPLETE, onVideoFinished);
			cutScreenMovie.addEventListener(VideoEvent.READY, onVideoReady);
			cutScreenMovie.visible = false;
			videoHolder.addChild(cutScreenMovie);
			//cutScreenMovie.load();
			cutScreenMovie.source = mediaURL;
		}
		
		public function removeVideo():void {
			if(cutScreenMovie) {
				cutScreenMovie.removeEventListener(VideoEvent.COMPLETE, onVideoFinished);
				cutScreenMovie.removeEventListener(VideoEvent.READY, onVideoReady);
				if(videoHolder.contains(cutScreenMovie)) {
					videoHolder.removeChild(cutScreenMovie);
					cutScreenMovie = null;
				}
			}
		}
		
		public function startVideo():void {
			if(currentlyPlaying == INTRO) {
				cutScreenMovie.play();
			} else {
				Tweener.addTween(this, {alpha:1, time:1, transition:"easeOutQuart"});
				Tweener.addTween(shiftSpacerWidth, {width:0, time:1, delay:1, transition:"easeOutQuart"});
				Tweener.addTween(shiftSpacerHeight, {height:0, time:1, delay:1, transition:"easeOutQuart", onComplete:playVideoProxy});
				
			}
		}
		
		private function playVideoProxy():void {
			cutScreenMovie.play();
		}
		
		private function onVideoReady(event_p:VideoEvent):void {
			cutScreenMovie.visible = true;
			var cutLoadedEvent:Event = new Event(CUT_LOADED);
			dispatchEvent(cutLoadedEvent);
		}
		
		private function onVideoFinished(event_p:VideoEvent):void {
			//leaveCut();
			if(currentlyPlaying == OUTRO) {
				var cutWaitingEvent:Event = new Event(CUT_WAITING);
				dispatchEvent(cutWaitingEvent);
			} else {
				finishCut();
			}
		}
		
		public function finishCut():void {
			Tweener.addTween(shiftSpacerWidth, {width:widthPushAmount, time:1, transition:"easeOutQuart"});
			Tweener.addTween(shiftSpacerHeight, {height:heightPushAmount, time:1, transition:"easeOutQuart", onComplete:dispatchCutDoneEvent});
			Tweener.addTween(this, {alpha:0, time:1, delay:1, transition:"easeOutQuart", onComplete:flipOff});
		}
		
		public function skipCut():void {
			SoundMixer.stopAll();
			removeVideo();
			//cutScreenMovie.playheadTime = totalTime;
			finishCut();
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