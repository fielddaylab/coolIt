package edu.wisc.doit.ls.coolit.view {
    import mx.controls.*;
	import mx.containers.VBox;
	import mx.events.*;
	
	import mx.logging.ILogger;
	import mx.logging.Log;
	
	import flash.events.*;
	import flash.utils.*;
	
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	
	import mx.collections.ArrayCollection;
	
	import mx.formatters.NumberFormatter;
	
	import mx.controls.dataGridClasses.DataGridColumn;
	
	import mx.charts.*;
	import mx.charts.series.LineSeries;
	
	/**
	 *  Handles capturing user action, and displaying updated data from model
	 *
	 *  @author Ben Longoria
	 */
	public class MasterGraphView extends VBox {		
		
		//MXML components
		public var addEntry:Button;
		public var removeEntry:Button;
		[Bindable] public var decFormatter:NumberFormatter;
		[Bindable] public var lineChart:LineChart;
		[Bindable] public var mainHorizontalAxis:LinearAxis;
		[Bindable] public var mainVerticalAxis:LinearAxis;
		[Bindable] public var snapList:DataGrid;
		
		[Bindable] public var modelLocator:CoolItModelLocator;
		[Bindable] public var coolerData:ArrayCollection;
		[Bindable] public var coolerModel:CoolerModel;
		[Bindable] public var stateSnapshot:StateSnapshotVO;
		
		private var _selected:Boolean = false;
		private var _dataProvider:ArrayCollection;
		
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function MasterGraphView():void {
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
			addEntry.addEventListener(MouseEvent.CLICK, onAddEntryClick);
			removeEntry.addEventListener(MouseEvent.CLICK, onRemoveEntryClick);
			snapList.addEventListener(Event.CHANGE, onCaptureChange);
		}
		
		private function onCaptureChange(event_p:Event):void {
			var selCapture:StateSnapshotVO = snapList.selectedItem as StateSnapshotVO;
			
			var selectCapture:SelectStateCaptureEvent = new SelectStateCaptureEvent();
			selectCapture.modelLocator = modelLocator;
			selectCapture.stateSnapshot = selCapture;
			CairngormEventDispatcher.getInstance().dispatchEvent(selectCapture);
		}
		
		private function onRemoveEntryClick(event_p:MouseEvent):void {
			var removeNewCapture:RemoveStateCaptureEvent = new RemoveStateCaptureEvent();
			removeNewCapture.modelLocator = modelLocator;
			CairngormEventDispatcher.getInstance().dispatchEvent(removeNewCapture);
		}
		
		private function onAddEntryClick(event_p:MouseEvent):void {
			var addNewCapture:AddNewStateCaptureEvent = new AddNewStateCaptureEvent();
			addNewCapture.modelLocator = modelLocator;
			CairngormEventDispatcher.getInstance().dispatchEvent(addNewCapture);
		}
		
		public function dataLabelFormat(item_p:Object, column_p:DataGridColumn):String {
			//decFormatter
			return decFormatter.format(item_p.data as Number);
		}
		
		[Bindable] public function get selected():Boolean {
			return _selected;
		}
		public function set selected(selected_p:Boolean):void {
			if(selected_p) {
				lineChart.validateNow();
			}
			_selected = selected_p;
		}
		
		[Bindable] public function get dataProvider():ArrayCollection {
			return _dataProvider;
		}
		public function set dataProvider(dataProvider_p:ArrayCollection):void {
			if(dataProvider_p) {
				if(_dataProvider) {
					_dataProvider.removeEventListener(CollectionEvent.COLLECTION_CHANGE, onProviderChange);
				}
				//mark as needing display
				_dataProvider = dataProvider_p;
				invalidateProperties();
				_dataProvider.addEventListener(CollectionEvent.COLLECTION_CHANGE, onProviderChange);
			}
		}
		
		private function onProviderChange(event_p:CollectionEvent):void {
			if(_selected) {
				invalidateProperties();
			}
		}
		
		override protected function commitProperties():void {
			super.commitProperties();
			
			if(_dataProvider) {
				if(_dataProvider.length > 0) {
					//re-build chart
					//loop through provider, for each set add two lineseries
					var dataLen:Number = _dataProvider.length;
					var highestValue:Number = 0;
					//log.fatal("{0} - !dataLen: " + dataLen, getQualifiedClassName(this) + ".commitProperties");
					//create a set of line series for the snap shot named for the iteration
					var newSeries:Array = new Array();
					for(var i:Number = 0; i<dataLen; i++) {
						//get snapshot vo
						var curSnapshot:StateSnapshotVO = _dataProvider.getItemAt(i) as StateSnapshotVO;
						curSnapshot.label = "Snapshot " + (i+1);
						
						if(curSnapshot.highestDataValue > highestValue) {
							highestValue = curSnapshot.highestDataValue;
						}
						 
						var lineSeries1:LineSeries = new LineSeries();
						lineSeries1.id = "id1" + i;
						lineSeries1.yField = "coolingOutputWatts";
						lineSeries1.displayName = "Output Cooling Power (Watts) " + (i + 1);
						lineSeries1.verticalAxis = mainVerticalAxis;
						lineSeries1.horizontalAxis = mainHorizontalAxis;
						lineSeries1.dataProvider = curSnapshot.captureData;
						lineSeries1.setStyle("lineStroke", curSnapshot.coolerStroke);
						//log.fatal("{0} - curSnapshot.highestHeatLeakValue: " + curSnapshot.highestHeatLeakValue + " curSnapshot.highestCoolingValue: " + curSnapshot.highestCoolingValue, getQualifiedClassName(this) + ".commitProperties");
						var lineSeries2:LineSeries = new LineSeries();
						lineSeries2.id = "id2" + i;
						lineSeries2.yField = "heatLeakWatts";
						lineSeries2.displayName = "Heat Leak (Watts) " + (i + 1);
						lineSeries2.verticalAxis = mainVerticalAxis;
						lineSeries2.horizontalAxis = mainHorizontalAxis;
						lineSeries2.dataProvider = curSnapshot.captureData;
						lineSeries2.setStyle("lineStroke", curSnapshot.heatLeakStroke);
						
						//newSeries.dataProvider = curSnapshot.captureData;
						newSeries.push(lineSeries1);
						newSeries.push(lineSeries2);
						
					}
					lineChart.series = newSeries;
					//lineChart.validateNow();
					mainVerticalAxis.maximum = highestValue;
					
					//lineChart.dataProvider = _dataProvider;
				}
			}
			
		}
		
	}
}