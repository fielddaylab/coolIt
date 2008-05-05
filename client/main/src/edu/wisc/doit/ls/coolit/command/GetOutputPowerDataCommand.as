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
	public class GetOutputPowerDataCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		private var coolerModel:CoolerModel;
		
		public function GetOutputPowerDataCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var getOutputPowerEvent:GetOutputPowerDataEvent = event_p as GetOutputPowerDataEvent;
			model = getOutputPowerEvent.modelLocator;
			coolerModel = model.coolerModel;
			
			var coolerName:String = getOutputPowerEvent.coolerName;
			var powerFactor:Number = getOutputPowerEvent.powerFactor;
			
			/*
			 //reset cooler model
			 coolerModel.currentData.removeAll();
			 
			 var delegate:CoolItDelegate = new CoolItDelegate(this);
			 
			 //do a 300 count iteration calling get date method each time
			 for(var i:Number = 0; i<301; i++) {
			 delegate.getOutputPowerData(coolerName, powerFactor, i);
			 }
			 */
			result(new Object());
		}
		
		public function result(event_p:Object):void {		
			//DUMMY START
			//do a 300 count iteration calling get date method each time
			coolerModel.currentData.removeAll();
			for(var i:Number = 0; i<301; i++) {
				var newDPXML:XML =  <DataPoint><temp>{i}</temp><data>{Math.round(i * 0.01)}</data></DataPoint>;
				var newDataPoint:DataPointVO = new DataPointVO(newDPXML);
				coolerModel.currentData.addItem(newDataPoint);
			}
			//DUMMY END
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}