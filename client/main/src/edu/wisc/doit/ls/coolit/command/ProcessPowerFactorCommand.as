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
	public class ProcessPowerFactorCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function ProcessPowerFactorCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var processPowerFactor:ProcessPowerFactorEvent = event_p as ProcessPowerFactorEvent;
			model = processPowerFactor.modelLocator;
			
			var stateModel:StateModel = model.stateModel;
			//log.fatal("{0} - stateModel.workAreaState: " + stateModel.workAreaState, getQualifiedClassName(this) + ".execute");
			if(stateModel.workAreaState == StateModel.SKETCH_STATE) {
				model.sketchCount = 20;
				
				//capture existing cooler setting
				var curPowerFactor:Number = model.powerFactor;
				
				//divide up the power factor range by sketch count
				//for each count, dispatch set cooler with the new power factor.
				
				//get the spread amount
				var powerFactorMax:Number = 1;
				var powerFactorMin:Number = 0.01;
				
				var spreadAmount:Number = powerFactorMax - powerFactorMin;
				var dividedAmount:Number = spreadAmount/model.sketchCount;
				
				for(var i:Number = 0; i<model.sketchCount; i++) {
					var newPowerFactor:Number = (i+1) * dividedAmount;
					dispatchSetCooler(newPowerFactor);
				}
				
				//TODO - do one more to reset cooler back to what it was with OG settings
				dispatchSetCooler(curPowerFactor);
			}
			
		}
		
		public function result(event_p:Object):void {
			
		}
		
		private function dispatchSetCooler(powerFactor_p:Number):void {
			var setCoolerEvent:SetCoolerEvent = new SetCoolerEvent();
			setCoolerEvent.modelLocator = model;
			setCoolerEvent.cooler = model.coolerModel.selected;
			setCoolerEvent.powerFactor = powerFactor_p;
			setCoolerEvent.powerSetting = model.powerSetting;
			CairngormEventDispatcher.getInstance().dispatchEvent(setCoolerEvent);
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}