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
	public class LoginView extends VBox {		
		
		//MXML components
		public var login:Button;
		public var accountId:TextInput;
		public var splashLogo:Image;
		public var loginBox:HBox;
		
		[Bindable]
		public var model:CoolItModelLocator;
		
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function LoginView():void {
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
			
			login.addEventListener(MouseEvent.CLICK, onLoginClick);
		}
		
		/*
		 * Catches mouse click from login button
		 *
		 * @param	event_p	MouseEvent
		 */
		private function onLoginClick(event_p:MouseEvent):void {
			loginBox.visible = false;
			Tweener.addTween(splashLogo, {alpha:0.0, time:0.5, transition:"linear", onComplete:dispatchLoginEvent});
		}
		
		private function dispatchLoginEvent():void {
			var loginEvent:LoginEvent = new LoginEvent();
			loginEvent.modelLocator = model;
			loginEvent.accountId = accountId.text;
			CairngormEventDispatcher.getInstance().dispatchEvent(loginEvent);
		}
	}
}