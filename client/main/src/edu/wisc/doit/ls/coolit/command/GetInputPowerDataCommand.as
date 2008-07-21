package edu.wisc.doit.ls.coolit.command {
	import flash.utils.*;
	import mx.rpc.IResponder;
	
	import mx.collections.ArrayCollection;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.*;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.business.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	import edu.wisc.doit.ls.coolit.CommonBase;
	
	/**
	 * 
	 */
	public class GetInputPowerDataCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		private var coolerModel:CoolerModel;
		
		public function GetInputPowerDataCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var getInputPowerEvent:GetInputPowerDataEvent = event_p as GetInputPowerDataEvent;
			model = getInputPowerEvent.modelLocator;
			coolerModel = model.coolerModel;
			
			var cryoLibModel:CryoLibModel = model.cryoLibModel;
			var coolerName:String = getInputPowerEvent.coolerName;
			var powerFactor:Number = getInputPowerEvent.powerFactor;
			
			
			coolerModel.currentPowerMax = coolerModel.inputPowerMax;
			//coolerModel.currentData.removeAll();
			
			var tempData:Array = new Array();
			var outputData:Array = new Array();
			for(var i:Number = 0; i<301; i++) {
				var curTemp:Number = i;
				var curData:Number = cryoLibModel.calculateInputPower(curTemp, powerFactor, coolerModel.selected);
				var curOutput:Number = cryoLibModel.calculateOutputPower(curTemp, powerFactor, coolerModel.selected);
				if(curData >= 0) {
					var newDPXML:XML =  <DataPoint><temp>{curTemp}</temp><data>{curData}</data></DataPoint>;
					var newDataPoint:DataPointVO = new DataPointVO(newDPXML);
					//coolerModel.currentData.addItem(newDataPoint);
					tempData.push(newDataPoint);
				}
				var newDPXML2:XML =  <DataPoint><temp>{curTemp}</temp><data>{curOutput}</data></DataPoint>;
				var newDataPoint2:DataPointVO = new DataPointVO(newDPXML2);
				//coolerModel.currentData.addItem(newDataPoint);
				outputData.push(newDataPoint2);
			}
			
			coolerModel.outputPowerData = new ArrayCollection(outputData);
			coolerModel.outputPowerData.refresh();
			coolerModel.currentData = new ArrayCollection(tempData);
			coolerModel.currentData.refresh();
			
			//dispatchUpdateStateCapture();
		}
		
		public function result(event_p:Object):void {}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
		public function dispatchUpdateStateCapture():void {
			var updateCapture:UpdateStateCaptureEvent = new UpdateStateCaptureEvent();
			updateCapture.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(updateCapture);
		}
		
	}
	
}