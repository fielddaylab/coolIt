package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.*;
	import mx.events.*;
	import mx.core.UIComponent;
	
	import mx.collections.ArrayCollection;
	import mx.formatters.NumberFormatter;
	import mx.logging.ILogger;
	import mx.logging.Log;
	
	import flash.events.*;
	import flash.utils.*;
	import flash.geom.Rectangle;
	import flash.display.Graphics;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class GraphView extends VBox {		
		
		//MXML components
		[Bindable] public var spriteCanvas:Canvas;
		public var yValues:VBox;
		public var xValues:HBox;
		public var xLabel1:Label;
		public var xLabel2:Label;
		public var xLabel3:Label;
		public var yLabel1:Label;
		public var yLabel2:Label;
		public var yLabel3:Label;
		
		public var decFormatter:NumberFormatter;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var yGraphic:Class;
		[Bindable] public var xGraphic:Class;
		
		private var _dataProvider:ArrayCollection;
		
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function GraphView():void {
			super();
			
			//set up logging
			log = Log.getLogger(ApplicationClass.APP_CATEGORY);
			log.debug("{0} - View instantiated", getQualifiedClassName(this));
			
			addEventListener(FlexEvent.CREATION_COMPLETE, onComplete);
			addEventListener(ResizeEvent.RESIZE, onResize);
		}
		
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
		private function onComplete(event_p:FlexEvent):void {
			log.debug("{0} - creationComplete called", getQualifiedClassName(this) + ".onComplete");
			invalidateProperties();
		}
		
		[Bindable] public function get dataProvider():ArrayCollection {
			return _dataProvider;
		}
		public function set dataProvider(data_p:ArrayCollection):void {
			if(_dataProvider) {
				_dataProvider.removeEventListener(CollectionEvent.COLLECTION_CHANGE, onGraphDataChange);
			}
			_dataProvider = data_p;
			_dataProvider.addEventListener(CollectionEvent.COLLECTION_CHANGE, onGraphDataChange);
			invalidateSize();
		}
		
		override protected function commitProperties():void {
			super.commitProperties();
			buildGraph();
		}
		
		override protected function measure():void {
			super.measure();
			buildGraph();
		}
		
		private function onGraphDataChange(event_p:CollectionEvent):void {
			invalidateSize();
		}
		
		private function buildGraph():void {
			var pad:Graphics = spriteCanvas.graphics;
			pad.clear();
			pad.lineStyle(0.5, 0x000000);
			
			if(dataProvider) {
				var dataLen:Number = dataProvider.length;
				var widthUnit:Number;
				var heightUnit:Number;
				var highestTemp:Number = 0;
				var highestData:Number = 0;
				
				//find largest values in list, then set width/height units
				for(var j:Number = 0; j<dataLen; j++) {
					var curData:Object = dataProvider.getItemAt(j) as Object;
					if(curData.temp > highestTemp) {
						highestTemp = curData.temp;
					}
					if(curData.data > highestData) {
						highestData = curData.data;
					}
				}
				
				widthUnit = spriteCanvas.width / highestTemp;
				heightUnit = (spriteCanvas.height-0.5) / highestData;
				
				//set label values
				xLabel1.text = "0";
				xLabel2.text = Math.round(highestTemp/2).toString();
				xLabel3.text = Math.round(highestTemp).toString();
				yLabel1.text = decFormatter.format(highestData).toString();
				yLabel2.text = decFormatter.format(highestData/2).toString();
				yLabel3.text = "0";
				
				//step through each data item and draw
				for(var i:Number = 0; i<dataLen; i++) {
					var curData:Object = dataProvider.getItemAt(i) as Object;
					var xAmount:Number = curData.temp * widthUnit;
					var yAmount:Number = (spriteCanvas.height+0.5) - (curData.data * heightUnit);
					if(i == 0) {
						pad.moveTo(xAmount, yAmount);
					} else {
						pad.lineTo(xAmount, yAmount);
					}
				}
			}
			
		}
		
		private function onResize(event_p:ResizeEvent):void {
			invalidateProperties();
		}
		
	}
}