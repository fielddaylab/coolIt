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
	public class GetCoolerListCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		private var coolerModel:CoolerModel;
		
		public function GetCoolerListCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var getCoolersEvent:GetCoolerListEvent = event_p as GetCoolerListEvent;
			model = getCoolersEvent.modelLocator;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.getCoolers();
		}
		
		public function result(event_p:Object):void {		
			var cleanedXML:XML = model.removeNamespaces(event_p.result);			
			model.coolerModel = new CoolerModel(cleanedXML);
			coolerModel = model.coolerModel;
			coolerModel.selected = coolerModel.coolers.getItemAt(0) as CoolerVO;
			//dispatch set cooler event
			dispatchSetCooler();
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
		public function dispatchSetCooler():void {
			//send out a set cooler event with currently selected cooler
			var setCoolerEvent:SetCoolerEvent = new SetCoolerEvent();
			setCoolerEvent.modelLocator = model;
			setCoolerEvent.cooler = coolerModel.selected;
			setCoolerEvent.powerFactor = coolerModel.defaultPowerFactor;
			setCoolerEvent.powerSetting = coolerModel.defaultPowerSetting;
			CairngormEventDispatcher.getInstance().dispatchEvent(setCoolerEvent);
		}
	}
	
}