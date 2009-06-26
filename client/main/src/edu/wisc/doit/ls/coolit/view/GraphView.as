package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.*;
	import mx.events.*;
	import mx.core.UIComponent;
	import mx.core.Application;
	
	import mx.collections.ArrayCollection;
	import mx.formatters.NumberFormatter;
	import mx.logging.ILogger;
	import mx.logging.Log;
	
	import flash.events.*;
	import flash.utils.*;
	import flash.geom.Rectangle;
	import flash.display.Graphics;
	import flash.display.Sprite;
	import flash.text.TextFormat;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	import mx.charts.HitData;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class GraphView extends VBox {		
		
		//MXML components
		[Bindable] public var spriteCanvas:UIComponent;
		[Bindable] public var lineCanvas:UIComponent;
		public var decFormatter:NumberFormatter;
				
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var horizontalMaximum:Number;
		[Bindable] public var horizontalMinimum:Number = 0;
		[Bindable] public var verticalMaximum:Number;
		[Bindable] public var yAxisLabel:String = "y";
		[Bindable] public var xAxisLabel:String = "Temp (Deg K)";
		[Bindable] public var yAxisGraphic:*;
		[Bindable] public var xAxisGraphic:*;
		
		private var _dataProvider:ArrayCollection;
		
		private var log:ILogger;
		
		private var isComplete:Boolean = false;
		
		/*
		 * Constructor
		 */
		public function GraphView():void {
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
			isComplete = true;
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
		}
		
		public function refresh():void {
			//buildGraph();
		}
		
		private function onGraphDataChange(event_p:CollectionEvent):void {
		}
		
		public function dataTipFunction(hitData_p:HitData):String {
			var formattedX:String = decFormatter.format(hitData_p.item.temp);
			var formattedY:String = decFormatter.format(hitData_p.item.data);
			var dataTip:String = "(" + formattedX + "," + formattedY + ")";
			
			return dataTip;
		}
	}
}