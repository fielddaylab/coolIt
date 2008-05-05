package edu.wisc.doit.ls.coolit.command {
	import flash.utils.*;
	import mx.rpc.IResponder;
	
	import mx.collections.ArrayCollection;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.CairngormEvent;
	
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
			
			var coolerName:String = getInputPowerEvent.coolerName;
			var powerFactor:Number = getInputPowerEvent.powerFactor;
			
			//reset cooler model
			coolerModel.currentData.removeAll();
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			
			//do a 300 count iteration calling get date method each time
			for(var i:Number = 250; i<301; i++) {
				delegate.getInputPowerData(coolerName, powerFactor, i);
			}
		}
		
		public function result(event_p:Object):void {		
			//result should be number
			var cleanedXML:XML = model.removeNamespaces(event_p.result);
			log.fatal("{0} - cleanedXML.InputPowerResult: " + cleanedXML.InputPowerResult, getQualifiedClassName(this) + ".result");
			//InputPowerResponse
			//InputPowerResult
			
			/*
			var powerResult:Number = parseFloat(event_p.result);
			//add this number to current data on cooler model
			var currentData:ArrayCollection = coolerModel.currentData;
			var currentLen:Number = currentData.length;
			//add a new data point object
			var newDataPoint:DataPointVO = new DataPointVO(new XML());
			newDataPoint.temp = currentLen-1;
			newDataPoint.data = powerResult;
			*/
			//currentData.addItem(newDataPoint);
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}