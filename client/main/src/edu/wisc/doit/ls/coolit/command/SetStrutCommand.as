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
	public class SetStrutCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		private var materialModel:MaterialModel;
		private var material:MaterialVO;
		private var length:Number;
		private var crossSection:Number;
		
		public function SetStrutCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var setStrutEvent:SetStrutEvent = event_p as SetStrutEvent;
			model = setStrutEvent.modelLocator;
			materialModel = model.materialModel;
			material = setStrutEvent.material;
			length = setStrutEvent.length;
			crossSection = setStrutEvent.crossSection;
			
			model.servicesOut++;
			
			var newPropCache:Object = new Object();
			newPropCache.length = length;
			newPropCache.crossSection = crossSection;
			materialModel.propertyCache.addItem(newPropCache);
			
			//model.strutLength = length;
			//model.crossSection = crossSection;
			if(materialModel.propertyCache.length > 0) {
				var curPropCache:Object = materialModel.propertyCache.getItemAt(0) as Object;
				model.strutLength = curPropCache.length;
				model.crossSection = curPropCache.crossSection;
			}
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.setStrut(material.name, setStrutEvent.length, setStrutEvent.crossSection);
		}
		
		public function result(event_p:Object):void {	
			model.servicesOut--;
			//set the current data with the current material data
			materialModel.currentData = material.mp;
			
			//remove first item
			if(materialModel.propertyCache.length > 0) {
				var curPropCache:Object = materialModel.propertyCache.removeItemAt(0) as Object;
				model.strutLength = curPropCache.length;
				model.crossSection = curPropCache.crossSection;
			}
						
			//also, now that the strut has been changed, do run sim too
			dispatchRunSimEvent();
		}
		
		private function dispatchRunSimEvent():void {
			var runSimEvent:RunSimulationEvent = new RunSimulationEvent();
			runSimEvent.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(runSimEvent);
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
	}
	
}