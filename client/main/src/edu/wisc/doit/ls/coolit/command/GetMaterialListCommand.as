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
	public class GetMaterialListCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		private var materialModel:MaterialModel;
		
		public function GetMaterialListCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var getMaterialsEvent:GetMaterialListEvent = event_p as GetMaterialListEvent;
			model = getMaterialsEvent.modelLocator;
			
			model.servicesOut++;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.getMaterials();
		}
		
		public function result(event_p:Object):void {		
			var cleanedXML:XML = model.removeNamespaces(event_p.result);			
			model.materialModel = new MaterialModel(cleanedXML);
			materialModel = model.materialModel;
			materialModel.selected = materialModel.materials.getItemAt(0) as MaterialVO;
			
			model.servicesOut--;
			
			//now "set" the first strut in the stack
			dispatchSetStrut();
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
		public function dispatchSetStrut():void {
			//send out a set cooler event with currently selected cooler
			
			var setStrutEvent:SetStrutEvent = new SetStrutEvent();
			setStrutEvent.modelLocator = model;
			setStrutEvent.material = materialModel.selected;
			setStrutEvent.length = materialModel.defaultLength;
			setStrutEvent.crossSection = materialModel.defaultCrossSection;
			CairngormEventDispatcher.getInstance().dispatchEvent(setStrutEvent);
		}
	}
	
}