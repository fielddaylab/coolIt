package edu.wisc.doit.ls.coolit.command {
	import flash.utils.*;
	import mx.rpc.IResponder;
	
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
	public class SetCoolerCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		private var coolerModel:CoolerModel;
		private var cooler:CoolerVO;
		private var powerFactor:Number;
		private var powerSetting:String;
		
		public function SetCoolerCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var setCoolerEvent:SetCoolerEvent = event_p as SetCoolerEvent;
			model = setCoolerEvent.modelLocator;
			coolerModel = model.coolerModel;
			cooler = setCoolerEvent.cooler;
			powerFactor = setCoolerEvent.powerFactor;
			powerSetting = setCoolerEvent.powerSetting;
			
			model.servicesOut++;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.setCooler(cooler.name, setCoolerEvent.powerFactor);
		}
		
		public function result(event_p:Object):void {		
			//var cleanedXML:XML = model.removeNamespaces(event_p.result);			
			//model.materialModel = new MaterialModel(cleanedXML);
			coolerModel.selected = cooler;
			var cryoLibModel:CryoLibModel = model.cryoLibModel;
			
			model.servicesOut--;
			
			model.powerFactor = powerFactor;
			model.powerSetting = powerSetting;
			
			if(powerSetting == CoolerModel.INPUT_POWER) {
				dispatchEventGetInputPowerData();
			} else {
				dispatchEventGetOutputPowerData();
			}
			
			
			//determine input and output power max
			var outputPowerMax:Number = cryoLibModel.calculateOutputPower(300, 1, coolerModel.selected);
			coolerModel.outputPowerMax = outputPowerMax;
			
			var inputPowerMax:Number = 0;
			//to determine input power max, we need to loop over power factor 1, with temperatures, find highest, then set that
			for(var i:Number = 0; i<301; i++) {
				var curTemp:Number = i;
				var curData:Number = cryoLibModel.calculateInputPower(curTemp, 1, coolerModel.selected);
				if(curData > inputPowerMax) {
					inputPowerMax = curData;
				}
			}
			//now set the highest
			coolerModel.inputPowerMax = inputPowerMax;
			log.fatal("{0} - inputPowerMax: " + inputPowerMax, getQualifiedClassName(this) + ".result");
			if(powerSetting == CoolerModel.INPUT_POWER) {
				coolerModel.currentPowerMax = coolerModel.inputPowerMax;
			} else {
				coolerModel.currentPowerMax = coolerModel.outputPowerMax;
			}
			
			//also, now that the cooler has been changed, do run sim too
			dispatchRunSimEvent();
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
		private function dispatchRunSimEvent():void {
			var runSimEvent:RunSimulationEvent = new RunSimulationEvent();
			runSimEvent.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(runSimEvent);
		}
		
		private function dispatchEventGetOutputPowerData():void {
			var getOutputPowerData:GetOutputPowerDataEvent = new GetOutputPowerDataEvent();
			getOutputPowerData.modelLocator = model;
			getOutputPowerData.coolerName = coolerModel.selected.name;
			getOutputPowerData.powerFactor = powerFactor;
			CairngormEventDispatcher.getInstance().dispatchEvent(getOutputPowerData);
		}
		
		private function dispatchEventGetInputPowerData():void {
			var getInputPowerData:GetInputPowerDataEvent = new GetInputPowerDataEvent();
			getInputPowerData.modelLocator = model;
			getInputPowerData.coolerName = coolerModel.selected.name;
			getInputPowerData.powerFactor = powerFactor;
			CairngormEventDispatcher.getInstance().dispatchEvent(getInputPowerData);
		}
		
	}
	
}