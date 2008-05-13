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
	public class GetSpecificPowerDataCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function GetSpecificPowerDataCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var getPowerData:GetSpecificPowerDataEvent = event_p as GetSpecificPowerDataEvent;
			model = getPowerData.modelLocator;
			
			model.servicesOut++;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.getSpecificPowerData();
		}
		
		public function result(event_p:Object):void {
			model.servicesOut--;
			//set the current data with the current material data
			var cleanedXML:XML = model.removeNamespaces(event_p.result);
			
			var voList:ArrayCollection = new ArrayCollection();
			for each (var dataPoint:XML in cleanedXML.GetSpecificPowerDataResult.DataPoint) {
				var newDataPoint:DataPointVO = new DataPointVO(dataPoint);
				voList.addItem(newDataPoint);
			}
			
			var cryoLibModel:CryoLibModel = model.cryoLibModel;
			cryoLibModel.initSpecificPowerData(voList);
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}