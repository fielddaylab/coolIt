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
			
			var cryoLibModel:CryoLibModel = model.cryoLibModel;
			var coolerName:String = getInputPowerEvent.coolerName;
			var powerFactor:Number = getInputPowerEvent.powerFactor;
			
			coolerModel.currentData.removeAll();
			for(var i:Number = 0; i<301; i++) {
				var curTemp:Number = i;
				var curData:Number = cryoLibModel.calculateInputPower(curTemp, powerFactor, coolerModel.selected)
				var newDPXML:XML =  <DataPoint><temp>{curTemp}</temp><data>{curData}</data></DataPoint>;
				var newDataPoint:DataPointVO = new DataPointVO(newDPXML);
				coolerModel.currentData.addItem(newDataPoint);
			}
		}
		
		public function result(event_p:Object):void {}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}