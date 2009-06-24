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
		public var loginHolder:Canvas;
		public var introHolder:HBox;
		public var continueGame:Button;
		public var emailField:TextInput;
		public var messageField:Label;
		public var cancel:Button;
		[Bindable] public var loginBox:Panel;
		
		[Bindable] public var model:CoolItModelLocator;
		
		public var emailPrompt:String = "Enter email address";
		
		private var log:ILogger;
		
		private var _loginState:String = StateModel.SIGNED_OUT;
		
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
			continueGame.addEventListener(MouseEvent.CLICK, onContinueClick);
			cancel.addEventListener(MouseEvent.CLICK, onCancelClick);
			
			emailField.addEventListener(FocusEvent.FOCUS_IN, onEmailFieldFocus);
			emailField.addEventListener(FocusEvent.FOCUS_OUT, onEmailFieldBlur);
		}
		
		private function onEmailFieldFocus(event_p:FocusEvent):void {
			if(emailField.text == emailPrompt) {
				emailField.setStyle("color", 0x385072);
				emailField.text = "";
			}
		}
		
		private function onEmailFieldBlur(event_p:FocusEvent):void {
			if(emailField.text == "") {
				emailField.setStyle("color", 0xADB6AE);
				emailField.text = emailPrompt;
			}
		}
		
		/*
		 * Catches mouse click from login button
		 *
		 * @param	event_p	MouseEvent
		 */
		private function onLoginClick(event_p:MouseEvent):void {
			//Tweener.addTween(loginBox, {width:splashLogo.width - 50, height:250, time:0.25, transition:"linear", onComplete:showIntro});
			//loginBox.removeChild(loginHolder);
			if(emailField.text.indexOf("@") == -1) {
				emailField.errorString = "Enter a valid email address";
			} else {
				dispatchLoginEvent();
			}
		}
		
		private function showIntro():void {
			introHolder.visible = true;
			introHolder.percentWidth = 100;
			introHolder.percentHeight = 100;
			loginBox.title = "Intro";
			continueGame.visible = true;
		}
		
		private function onContinueClick(event_p:MouseEvent):void {
			var viewJobListEvent:ViewJobListEvent = new ViewJobListEvent();
			viewJobListEvent.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(viewJobListEvent);
		}
		
		private function onCancelClick(event_p:MouseEvent):void {
			messageField.height = 0;
			Tweener.addTween(loginBox, {width:splashLogo.width - 50, height:250, time:0.25, transition:"linear", onComplete:showIntro});
			loginBox.removeChild(loginHolder);
		}
		
		private function dispatchLoginEvent():void {
			var loginEvent:LoginEvent = new LoginEvent();
			loginEvent.modelLocator = model;
			loginEvent.accountId = emailField.text;
			loginEvent.newLogin = (_loginState == StateModel.INVALID_LOGIN) ? true : false;
			CairngormEventDispatcher.getInstance().dispatchEvent(loginEvent);
		}
		
		[Bindable] public function get loginState():String {
			return _loginState;
		}
		public function set loginState(state_p:String):void {
			switch(state_p) {
				case StateModel.INVALID_LOGIN:
					messageField.height = 20;
					emailField.errorString = "Double check your email address!";
					break;
				case StateModel.LOGGED_IN:
					messageField.height = 0;
					Tweener.addTween(loginBox, {width:splashLogo.width - 50, height:250, time:0.25, transition:"linear", onComplete:showIntro});
					loginBox.removeChild(loginHolder);
					break;
				default:
					messageField.height = 0;
			}
			
			_loginState = state_p;
		}
	}
}