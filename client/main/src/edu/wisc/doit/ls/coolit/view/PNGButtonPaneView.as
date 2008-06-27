package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.*;
	import mx.events.*;
	
	import mx.logging.ILogger;
	import mx.logging.Log;
	
	import flash.events.*;
	import flash.utils.*;
	import flash.geom.Point;
	
	import com.dougmccune.HitTester;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class PNGButtonPaneView extends VBox {		
		public static var CLICK_HIT_EVENT:String = "edu.wisc.doit.ls.coolit.view.PNGButtonPaneView.clickHitEvent";
		public static var MOUSE_OVER_TRANSPARENT:String = "edu.wisc.doit.ls.coolit.view.PNGButtonPaneView.mouseOverTransparent";
		
		//bindable properties
		[Bindable] public var upImage:*;
		[Bindable] public var overImage:*;
		[Bindable] public var downImage:*;
		
		
		//MXML components
		public var imageStack:ViewStack;
		public var imageUp:Image;
		public var imageOver:Image;
		public var imageDown:Image;
		
		private var _selected:Boolean = false;
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function PNGButtonPaneView():void {
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
			
			imageStack.addEventListener(MouseEvent.MOUSE_MOVE, onImageMouseMove);
			imageStack.addEventListener(MouseEvent.MOUSE_DOWN, onImageMouseDown);
			imageStack.addEventListener(MouseEvent.MOUSE_UP, onImageMouseUp);
		}
		
		[Bindable] public function get selected():Boolean {
			return _selected;
		}
		public function set selected(selected_p:Boolean):void {
			if(selected_p) {
				imageStack.selectedIndex = 2;
				//imageStack.removeEventListener(MouseEvent.MOUSE_MOVE, onImageMouseMove);
				imageStack.removeEventListener(MouseEvent.MOUSE_DOWN, onImageMouseDown);
				imageStack.removeEventListener(MouseEvent.MOUSE_UP, onImageMouseUp);
			} else {
				imageStack.selectedIndex = 0;
				//imageStack.addEventListener(MouseEvent.MOUSE_MOVE, onImageMouseMove);
				imageStack.addEventListener(MouseEvent.MOUSE_DOWN, onImageMouseDown);
				imageStack.addEventListener(MouseEvent.MOUSE_UP, onImageMouseUp);
			}
			_selected = selected_p;
		}
		
		private function onImageMouseUp(event_p:MouseEvent):void {
			var hitResult:Boolean = HitTester.realHitTest(imageDown, new Point(event_p.stageX, event_p.stageY));
			if(hitResult) {
				imageStack.selectedIndex = 1;
				var clickHitEvent:Event = new Event(CLICK_HIT_EVENT);
				dispatchEvent(clickHitEvent);
			} else {
				imageStack.selectedIndex = 0;
			}
		}
		
		private function onImageMouseDown(event_p:MouseEvent):void {
			var hitResult:Boolean = HitTester.realHitTest(imageOver, new Point(event_p.stageX, event_p.stageY));
			if(hitResult) {
				imageStack.selectedIndex = 2;
			} else {
				imageStack.selectedIndex = 0;
			}
		}
		
		private function onImageMouseMove(event_p:MouseEvent):void {
			var imageUpHitResult:Boolean = HitTester.realHitTest(imageUp, new Point(event_p.stageX, event_p.stageY));
			var imageDownHitResult:Boolean = HitTester.realHitTest(imageDown, new Point(event_p.stageX, event_p.stageY));
			var imageOverHitResult:Boolean = HitTester.realHitTest(imageOver, new Point(event_p.stageX, event_p.stageY));
			//do different actions depending on stack state
			
			if(selected) {
				if(!imageDownHitResult) {
					dispatchMouseOverTransparencyEvent();
				}
			} else {
				switch(imageStack.selectedIndex) {
					case 0:
					case 1:
						if(imageUpHitResult) {
							imageStack.selectedIndex = 1;
						} else {
							dispatchMouseOverTransparencyEvent();
							imageStack.selectedIndex = 0;
						}
						break;
						case 2:
						if(imageDownHitResult) {
							imageStack.selectedIndex = 2;
						} else {
							dispatchMouseOverTransparencyEvent();
							imageStack.selectedIndex = 0;
						}
						break;
						default:
						dispatchMouseOverTransparencyEvent();
						imageStack.selectedIndex = 0;
				}
			}
			
		}
		
		private function dispatchMouseOverTransparencyEvent():void {
			var mouseOverTransparency:Event = new Event(MOUSE_OVER_TRANSPARENT);
			dispatchEvent(mouseOverTransparency);
		}
		
	}
}