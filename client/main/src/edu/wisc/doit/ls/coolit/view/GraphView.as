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
	
	//flare
    import flare.vis.Visualization;
    import flare.vis.data.Data;
	import flare.vis.data.DataSprite;
    import flare.vis.operator.encoder.ColorEncoder;
    import flare.vis.operator.encoder.ShapeEncoder;
    import flare.vis.operator.layout.AxisLayout;
    import flare.vis.palette.ColorPalette;
	import flare.vis.axis.CartesianAxes;
	import flare.vis.axis.Axis;
	import flare.vis.axis.AxisGridLine;
	import flare.vis.axis.AxisLabel;
	import flare.vis.events.VisualizationEvent;
	import flare.display.TextSprite;
	import flare.animate.Transitioner;
	
	import caurina.transitions.Tweener;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class GraphView extends Canvas {		
		
		//MXML components
		[Bindable] public var spriteCanvas:UIComponent;
		
		//flare components
		[Bindable] public var vis:Visualization;
		
		public var decFormatter:NumberFormatter;
		
		[Bindable] public var model:CoolItModelLocator;
		[Bindable] public var yGraphic:Class;
		[Bindable] public var xGraphic:Class;
		[Bindable] public var yAxisLabelWidth:Number;
		[Bindable] public var xAxisLabelHeight:Number;
		
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
			addEventListener(ResizeEvent.RESIZE, onResize);
		}
		
		/*
		 * Catches event once interface has been initialized
		 *
		 * @param	event_p	FlexEvent once all UI is init'd
		 */
		private function onComplete(event_p:FlexEvent):void {
			log.debug("{0} - creationComplete called", getQualifiedClassName(this) + ".onComplete");
			isComplete = true;
			if(vis) {
				vis.update();				
				updateAxis();
			}
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
		
		public function refresh():void {
			buildGraph();
		}
		
		override protected function commitProperties():void {
			super.commitProperties();
			if(vis) {
				vis.update();
				updateAxis();
			}
		}
		
		override protected function measure():void {
			super.measure();
			buildGraph();
		}
		
		private function onGraphDataChange(event_p:CollectionEvent):void {
			invalidateSize();
		}
		
		private function onResize(event_p:ResizeEvent):void {
			if(vis) {
				vis.bounds = new Rectangle(0, 0, spriteCanvas.width, spriteCanvas.height);
				vis.update();
				updateAxis();
			}
			invalidateProperties();
		}
		
		private function buildGraph():void {
			if(dataProvider && isComplete) {
				buildData();
			}
		}
		
		private function buildData():void {
			var dataObject:Data = new Data();
			
			var dataLen:Number = dataProvider.length;
			for(var i:Number = 0; i<dataLen; i++) {
				var curRecord:DataPointVO = dataProvider.getItemAt(i) as DataPointVO;
				var chartData:Object = curRecord.chartData;
				//log.fatal("{0} - chartData.temp: " + chartData.temp + " chartData.data: " + chartData.data, getQualifiedClassName(this));
				dataObject.addNode(curRecord.chartData);
			}
			
			buildVis(dataObject);
		}
		
		private function buildVis(dataObject_p:Data):void {
			
			if(dataProvider.length > 0) {
				if(vis) {
					spriteCanvas.removeChild(vis);
					vis.removeEventListener(VisualizationEvent.UPDATE, onVisUpdate);
				}
				
				//log.fatal("{0} - dataObject_p.size: " + dataObject_p.size, getQualifiedClassName(this));
				vis = new Visualization(dataObject_p);
				vis.bounds = new Rectangle(0, 0, spriteCanvas.width, spriteCanvas.height);
				vis.x = 0;
				vis.y = 0; 
				
				vis.operators.add(new AxisLayout("data.temp", "data.data"));
				//vis.operators.add(new SCShapeEncoder("data.groupId"));
				//vis.operators.add(new SCShapeEncoder("data.word"));
				
				vis.addEventListener(VisualizationEvent.UPDATE, onVisUpdate);
				
				vis.update();
				
				updateAxis();
				//spriteCanvas.visible = true;
				//spriteCanvas.alpha = 0;
				//Tweener.addTween(spriteCanvas, {time:1, transition:"linear", alpha:1.0, delay: 1});
			}
			
        }
		
		private function onVisUpdate(event_p:VisualizationEvent):void {
			log.fatal("{0} - !!!!!!!onVisUpdate", getQualifiedClassName(this));
			
			/*
			spriteCanvas.validateProperties();
			spriteCanvas.validateNow();
			spriteCanvas.validateDisplayList();
			spriteCanvas.validateSize(true);
			*/
		}
		
		private function updateAxis():void {
			var cartAxes:CartesianAxes = vis.xyAxes;
			var xAxis:Axis = cartAxes.xAxis;
			var yAxis:Axis = cartAxes.yAxis;
			/*
			cartAxes.update();
			xAxis.update(null);
			yAxis.update(null);
			*/
			
			var cartAxes:CartesianAxes = vis.xyAxes;
			var xAxis:Axis = cartAxes.xAxis;
			var yAxis:Axis = cartAxes.yAxis;
			var xLine:AxisGridLine = cartAxes.xLine;
			var yLine:AxisGridLine = cartAxes.yLine;
			
			var format:TextFormat = new TextFormat();
			format.font = "Arial";
			format.size = 9;
			
			//"correct" x values
			var xAxisLabels:Sprite = xAxis.labels;
			var xLabelLen:Number = xAxisLabels.numChildren;
			for(var i:Number = 0; i<xLabelLen; i++) {
				var curLabel:AxisLabel = xAxisLabels.getChildAt(i) as AxisLabel;
				curLabel.setTextFormat(format);
			}
			
			//"correct" y values
			var yAxisLabels:Sprite = yAxis.labels;
			var yLabelLen:Number = yAxisLabels.numChildren;
			for(var i:Number = 0; i<yLabelLen; i++) {
				var curLabel:AxisLabel = yAxisLabels.getChildAt(i) as AxisLabel;
				curLabel.setTextFormat(format);
			}
			
			yAxisLabelWidth = yAxisLabels.width;
			xAxisLabelHeight = xAxisLabels.height;
			
			spriteCanvas.addChild(vis);
			
			//check for overlapping labels
			for(var i:Number = 0; i<yLabelLen; i++) {
				var curLabel:AxisLabel = yAxisLabels.getChildAt(i) as AxisLabel;
				//if this isn't the first label, check the label before and make sure it doesn't overlap
				//if it does overlap, make visible false
				if(i > 0) {
					var prevLabel:AxisLabel = yAxisLabels.getChildAt(i-1) as AxisLabel;
					if((curLabel.y + curLabel.height) > prevLabel.y && prevLabel.visible == true) {
						curLabel.visible = false;
					} else {
						curLabel.visible = true;
					}
				}
			}
			
			for(var i:Number = 0; i<xLabelLen; i++) {
				var curLabel:AxisLabel = xAxisLabels.getChildAt(i) as AxisLabel;
				if(i > 0) {
					var prevLabel:AxisLabel = xAxisLabels.getChildAt(i-1) as AxisLabel;
					if((prevLabel.x + prevLabel.width) > curLabel.x && prevLabel.visible == true) {
						curLabel.visible = false;
					} else {
						curLabel.visible = true;
					}
				}
			}
		}
		
	}
}