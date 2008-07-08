package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.*;
	import mx.events.*;
	import mx.collections.ArrayCollection;
	
	import mx.logging.ILogger;
	import mx.logging.Log;
	
	import flash.events.*;
	import flash.utils.*;
	import flash.net.*;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class NestedVideoView extends VBox {		
		public static var IMAGES_LOADED:String = "edu.wisc.doit.ls.coolit.view.NestedVideoView.imagesLoaded";
		
		//MXML components
		public var imageHolder:Canvas;
		public var mainImage1:Image;
		public var mainImage2:Image;
		public var currentImage:Image;
		public var inactiveImage:Image;
		public var topStack:ViewStack;
		
		//settable props
		[Bindable] public var firstDimensionMax:Number;
		[Bindable] public var firstDimensionMin:Number;
		[Bindable] public var secondDimensionMax:Number;
		[Bindable] public var secondDimensionMin:Number;
		
		private var log:ILogger;
		
		private var topLevel:ArrayCollection;
		private var imagesLoaded:Number = 0;
		
		private var _firstDimensionValue:Number = 0.1;
		private var _secondDimensionValue:Number = 0.89;
		
		private var currentTopIndex:Number = 4;
		private var currentNestedIndex:Number = 0;
		
		/*
		 * Constructor
		 */
		public function NestedVideoView():void {
			super();
			
			topLevel = new ArrayCollection();
			
			for(var i:Number = 0; i<5; i++) {
				var curNum:Number = i;
				var curDir:String = "./0" + curNum + "thickness/";
				var nestedList:ArrayCollection = new ArrayCollection();
				nestedList.addItem(curDir + "minesweeper_001.png");
				nestedList.addItem(curDir + "minesweeper_002.png");
				nestedList.addItem(curDir + "minesweeper_003.png");
				nestedList.addItem(curDir + "minesweeper_004.png");
				nestedList.addItem(curDir + "minesweeper_005.png");
				nestedList.addItem(curDir + "minesweeper_006.png");
				nestedList.addItem(curDir + "minesweeper_007.png");
				nestedList.addItem(curDir + "minesweeper_008.png");
				nestedList.addItem(curDir + "minesweeper_009.png");
				nestedList.addItem(curDir + "minesweeper_010.png");
				
				topLevel.addItem(nestedList);
			}
			
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
			
			buildViewStacks();
		}
		
		[Bindable] public function get firstDimensionValue():Number {
			return _firstDimensionValue;
		}
		public function set firstDimensionValue(value_p:Number):void {
			//if undefined or null
			if(value_p == undefined || !value_p && value_p != 0) {
				value_p = firstDimensionMin;
			}
			_firstDimensionValue = value_p;
			//calc first dimension slot
			calculateFirstDimensionSlot();
		}
		
		[Bindable] public function get secondDimensionValue():Number {
			return _secondDimensionValue;
		}
		public function set secondDimensionValue(value_p:Number):void {
			//if undefined or null
			if(value_p == undefined || !value_p && value_p != 0) {
				value_p = secondDimensionMin;
			}
			_secondDimensionValue = value_p;
			//calc second dimension slot
			calculateSecondDimensionSlot();
		}
		
		private function buildViewStacks():void {
			topStack = new ViewStack();
			
			var topLevelLen:Number = topLevel.length;
			for(var i:Number = 0; i<topLevelLen; i++) {
				var curNested:ArrayCollection = topLevel.getItemAt(i) as ArrayCollection;
				var nestLen:Number = curNested.length;
				var newStack:ViewStack = new ViewStack();
				for(var j:Number = 0; j<nestLen; j++) {
					var curImageURL:String = curNested.getItemAt(j) as String;
					
					var nestedStack:ViewStack = new ViewStack();
					var imageBox:Box = new Box();
					var nestedImage:Image = new Image();
					nestedImage.addEventListener(Event.COMPLETE, onLoaderComplete);
					nestedImage.addEventListener(IOErrorEvent.IO_ERROR, onLoaderError);
					nestedImage.source = curImageURL;
					nestedImage.width = 457;
					nestedImage.height = 280;
					imageBox.addChild(nestedImage);
					nestedStack.addChild(imageBox);
					
					newStack.addChild(nestedStack);
				}
				
				topStack.addChild(newStack);
			}
			
			addChild(topStack);
			
			updatedStackIndexes();
		}
		
		private function updatedStackIndexes():void {
			topStack.selectedIndex = currentTopIndex;
			var curNestedStack:ViewStack = topStack.getChildAt(currentTopIndex) as ViewStack;
			curNestedStack.selectedIndex = currentNestedIndex;
		}
		
		private function calculateFirstDimensionSlot():void {
			var indexValue:Number;
			var difference:Number = firstDimensionMax - firstDimensionMin;
			var dividedValue:Number = difference / topLevel.length;
			var indexCandidate:Number = _firstDimensionValue / dividedValue;
			indexValue = Math.round(indexCandidate);
			
			if(indexValue < 0) {
				indexValue = 0;
			} else if(indexValue > (topLevel.length-1)) {
				indexValue = topLevel.length-1;
			}
			currentTopIndex = indexValue;
			
			updatedStackIndexes();
		}
		
		private function calculateSecondDimensionSlot():void {
			var indexValue:Number;
			var difference:Number = secondDimensionMax - secondDimensionMin;
			var dividedValue:Number = difference / topLevel.getItemAt(0).length;
			var indexCandidate:Number = _secondDimensionValue / dividedValue;
			indexValue = Math.round(indexCandidate);
			if(indexValue < 0) {
				indexValue = 0;
			} else if(indexValue > (topLevel.getItemAt(0).length - 1)) {
				indexValue = topLevel.getItemAt(0).length - 1;
			}
			currentNestedIndex = (topLevel.getItemAt(0).length - 1) - indexValue;
			
			updatedStackIndexes();
			
		}
		
		private function onLoaderComplete(event_p:Event):void {
			var curLoader:Image = event_p.currentTarget as Image;
			curLoader.removeEventListener(Event.COMPLETE, onLoaderComplete);
			curLoader.removeEventListener(IOErrorEvent.IO_ERROR, onLoaderError);
			
			imagesLoaded++;
			dispatchImagesLoaded();
		}
		
		private function onLoaderError(event_p:IOErrorEvent):void {
			var curLoader:Image = event_p.currentTarget as Image;
			curLoader.removeEventListener(Event.COMPLETE, onLoaderComplete);
			curLoader.removeEventListener(IOErrorEvent.IO_ERROR, onLoaderError);
			
			imagesLoaded++;
			dispatchImagesLoaded();
		}
		
		private function dispatchImagesLoaded():void {
			if(imagesLoaded == ((topLevel.length) * (topLevel.getItemAt(0).length))) {
				var imagesAreLoaded:Event = new Event(IMAGES_LOADED);
				dispatchEvent(imagesAreLoaded);
			}
		}
	}
}