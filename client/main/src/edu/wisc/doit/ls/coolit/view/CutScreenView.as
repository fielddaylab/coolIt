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
		
		//MXML components
		public var splashLogo:Image;
		
		[Bindable] public var model:CoolItModelLocator;
		
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
			if(state_p != StateModel.CUT_SCREEN_STATE) {
				splashLogo.alpha = 0;
			} else {
				Tweener.addTween(splashLogo, {alpha:1.0, time:1, transition:"linear", onComplete:leaveCut});
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
		
		private function leaveCut():void {
			var leaveCutEvent:LeaveCutScreenEvent = new LeaveCutScreenEvent();
			leaveCutEvent.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(leaveCutEvent);
		}
	}
}