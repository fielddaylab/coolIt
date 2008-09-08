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
		public static var BACK_EVENT:String = "edu.wisc.doit.ls.coolit.MasterGraphView.backEvent";
		public static var COOLERS:String = "coolers";
		public static var SUPPORTS:String = "supports";
		
		//MXML components
		public var addEntry:Button;
		public var removeEntry:Button;
		public var backToMain:Button;
		public var pickerSelector:ComboBox;
		[Bindable] public var decFormatter:NumberFormatter;
		[Bindable] public var lineChart:LineChart;
		[Bindable] public var mainHorizontalAxis:LinearAxis;
		[Bindable] public var mainVerticalAxis:LinearAxis;
		[Bindable] public var snapList:DataGrid;
		
		[Bindable] public var modelLocator:CoolItModelLocator;
		[Bindable] public var coolerData:ArrayCollection;
		[Bindable] public var coolerModel:CoolerModel;
		[Bindable] public var stateSnapshot:StateSnapshotVO;
		
		[Bindable] public var selectedPickerIndex:Number = 0;
		[Bindable] public var pickersProvider:ArrayCollection;
		
		private var _selected:Boolean = false;
		private var _dataProvider:ArrayCollection;
		
		private var lineSeriesLookup:Object;
		
		private var lastHighestValue:Number = 0;
		
		private var log:ILogger;
		
		/*
		 * Constructor
		 */
		public function MasterGraphView():void {
			super();
			
			lineSeriesLookup = new Object();
			
			var picker1:Object = new Object();
			picker1.label = "Coolers ->";
			picker1.data = COOLERS;
			
			var picker2:Object = new Object();
			picker2.label = "Supports ->";
			picker2.data = SUPPORTS;
			
			pickersProvider = new ArrayCollection();
			pickersProvider.addItem(picker1);
			pickersProvider.addItem(picker2);
			
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
			pickerSelector.addEventListener(Event.CHANGE, onSelectPicker);
		}
		
		public function reset():void {
			var clearCapturesEvent:ClearStateCapturesEvent = new ClearStateCapturesEvent();
			clearCapturesEvent.modelLocator = modelLocator;
			CairngormEventDispatcher.getInstance().dispatchEvent(clearCapturesEvent);
		}
		
		private function onSelectPicker(event_p:Event):void {
			var selItem:Object = pickerSelector.selectedItem as Object;
			var pickerEvent:Event = new Event(selItem.data);
			dispatchEvent(pickerEvent);
		}
		
		public function selectCoolers():void {
			var pickerEvent:Event = new Event(COOLERS);
			dispatchEvent(pickerEvent);
		}
		
		public function selectSupports():void {
			var pickerEvent:Event = new Event(SUPPORTS);
			dispatchEvent(pickerEvent);
		}
		
		private function onBackClick(event_p:MouseEvent):void {
			var backEvent:Event = new Event(BACK_EVENT);
			dispatchEvent(backEvent);
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
				//lineChart.validateNow();
				invalidateProperties();
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
				var kind:String = event_p.kind;
				var items:Array = event_p.items;
				var itemLen:Number = items.length;
				
				log.fatal("{0} - kind: " + kind, getQualifiedClassName(this) + ".onProviderChange");
				if(kind == CollectionEventKind.UPDATE) {
					var lines:Object = lineSeriesLookup[snapList.selectedItem.id] as Object;
					//update dataproviders in lineseries
					lines.line1.dataProvider = stateSnapshot.captureData;
					lines.line2.dataProvider = stateSnapshot.captureData;
					
					findHighestValue();
					
					//update labels in dp
					updateLabels();
					
				} else if(kind == CollectionEventKind.ADD) {
					var curSnapshot:StateSnapshotVO = items[0] as StateSnapshotVO;
					var newIndex:Number = _dataProvider.length;
					curSnapshot.label = curSnapshot.material.name + "/" + curSnapshot.cooler.name + " " + newIndex;
					curSnapshot.curIndex = newIndex;
					var lineSeries1:LineSeries = new LineSeries();
					lineSeries1.id = "id1" + newIndex;
					lineSeries1.yField = "coolingOutputWatts";
					lineSeries1.displayName = "Output Cooling Power (Watts)";
					lineSeries1.verticalAxis = mainVerticalAxis;
					lineSeries1.horizontalAxis = mainHorizontalAxis;
					lineSeries1.dataProvider = curSnapshot.captureData;
					lineSeries1.setStyle("lineStroke", curSnapshot.coolerStroke);
					
					var lineSeries2:LineSeries = new LineSeries();
					lineSeries2.id = "id2" + newIndex;
					lineSeries2.yField = "heatLeakWatts";
					lineSeries2.displayName = "Heat Leak (Watts)";
					lineSeries2.verticalAxis = mainVerticalAxis;
					lineSeries2.horizontalAxis = mainHorizontalAxis;
					lineSeries2.dataProvider = curSnapshot.captureData;
					lineSeries2.setStyle("lineStroke", curSnapshot.heatLeakStroke);
					
					//add to lookup table
					var lines:Object = new Object();
					lines.line1 = lineSeries1;
					lines.line2 = lineSeries2;
					lineSeriesLookup[curSnapshot.id] = lines;
					
					var curSeries:Array = lineChart.series;
					curSeries.push(lineSeries1);
					curSeries.push(lineSeries2);
					
					lineChart.series = curSeries;
					
					lineChart.validateNow();
					
					var selectCapture:SelectStateCaptureEvent = new SelectStateCaptureEvent();
					selectCapture.modelLocator = modelLocator;
					selectCapture.stateSnapshot = curSnapshot;
					CairngormEventDispatcher.getInstance().dispatchEvent(selectCapture);
					
				} else {
					invalidateProperties();
				}
				//invalidateProperties();
				//update only the difference
			}
		}
		
		private function updateLabels():void {
			if(_dataProvider) {
				if(_dataProvider.length > 0) {
					var dataLen:Number = _dataProvider.length;
					for(var i:Number = 0; i<dataLen; i++) {
						//get snapshot vo
						var curSnapshot:StateSnapshotVO = _dataProvider.getItemAt(i) as StateSnapshotVO;
						//curSnapshot.label = "Snapshot " + (i+1);
						curSnapshot.label = curSnapshot.material.name + "/" + curSnapshot.cooler.name + " " + curSnapshot.curIndex;
					}
				}
			}
		}
		
		override protected function commitProperties():void {
			super.commitProperties();
			log.fatal("{0} - !! commitProperties CALLED", getQualifiedClassName(this) + ".commitProperties");
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
						//curSnapshot.label = "Snapshot " + (i+1);
						curSnapshot.label = modelLocator.materialModel.selected.name + "/" + coolerModel.selected.name + " " + (i+1);
						curSnapshot.curIndex = (i+1);
						if(curSnapshot.highestDataValue > highestValue) {
							highestValue = curSnapshot.highestDataValue;
						}
						
						var lineSeries1:LineSeries = new LineSeries();
						lineSeries1.id = "id1" + i;
						lineSeries1.yField = "coolingOutputWatts";
						lineSeries1.displayName = "Output Cooling Power (Watts)";
						lineSeries1.verticalAxis = mainVerticalAxis;
						lineSeries1.horizontalAxis = mainHorizontalAxis;
						lineSeries1.dataProvider = curSnapshot.captureData;
						lineSeries1.setStyle("lineStroke", curSnapshot.coolerStroke);
						//log.fatal("{0} - curSnapshot.highestHeatLeakValue: " + curSnapshot.highestHeatLeakValue + " curSnapshot.highestCoolingValue: " + curSnapshot.highestCoolingValue, getQualifiedClassName(this) + ".commitProperties");
						var lineSeries2:LineSeries = new LineSeries();
						lineSeries2.id = "id2" + i;
						lineSeries2.yField = "heatLeakWatts";
						lineSeries2.displayName = "Heat Leak (Watts)";
						lineSeries2.verticalAxis = mainVerticalAxis;
						lineSeries2.horizontalAxis = mainHorizontalAxis;
						lineSeries2.dataProvider = curSnapshot.captureData;
						lineSeries2.setStyle("lineStroke", curSnapshot.heatLeakStroke);
						
						//add to lookup table
						var lines:Object = new Object();
						lines.line1 = lineSeries1;
						lines.line2 = lineSeries2;
						lineSeriesLookup[curSnapshot.id] = lines;
						
						//newSeries.dataProvider = curSnapshot.captureData;
						newSeries.push(lineSeries1);
						newSeries.push(lineSeries2);
						
					}
					lineChart.series = newSeries;
					//lineChart.validateNow();
					updateMaxValue(highestValue);
					
					//lineChart.dataProvider = _dataProvider;
				}
			}
			
		}
		
		private function findHighestValue():void {
			if(_dataProvider) {
				if(_dataProvider.length > 0) {
					var dataLen:Number = _dataProvider.length;
					var highestValue:Number = 0;
					
					for(var i:Number = 0; i<dataLen; i++) {
						//get snapshot vo
						var curSnapshot:StateSnapshotVO = _dataProvider.getItemAt(i) as StateSnapshotVO;
						
						if(curSnapshot.highestDataValue > highestValue) {
							highestValue = curSnapshot.highestDataValue;
						}
						
					}
					
					updateMaxValue(highestValue);
				}
			}
		}
		
		private function updateMaxValue(value_p:Number):void {
			if(value_p > mainVerticalAxis.maximum || isNaN(mainVerticalAxis.maximum)) {
				mainVerticalAxis.maximum = value_p;
				lastHighestValue = value_p;
			}
			//mainVerticalAxis.maximum = value_p;
			//lastHighestValue = value_p;
			//lineChart.validateNow();
		}
		
		public function dataTipFunction(hitData_p:HitData):String {
			var temperature:String = decFormatter.format(hitData_p.item.temperature);
			var coolingOutputWatts:String = decFormatter.format(hitData_p.item.coolingOutputWatts);
			var heatLeakWatts:String = decFormatter.format(hitData_p.item.heatLeakWatts);
			var dataTip:String = "<b>Temp:</b> " + temperature + "<br/>";
			dataTip += "<b>Cooling Power:</b> " + coolingOutputWatts + "<br/>";
			dataTip += "<b>Heat Leak: </b>" + heatLeakWatts;
			
			return dataTip;
		}
	}
}