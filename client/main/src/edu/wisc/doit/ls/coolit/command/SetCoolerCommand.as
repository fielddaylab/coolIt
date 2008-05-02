package edu.wisc.doit.ls.coolit.command {
	import flash.utils.*;
	import mx.rpc.IResponder;
	
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
	public class SetCoolerCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function SetCoolerCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var setCoolerEvent:SetCoolerEvent = event_p as SetCoolerEvent;
			model = setCoolerEvent.modelLocator;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.setCooler(setCoolerEvent.coolerName, setCoolerEvent.powerFactor);
		}
		
		public function result(event_p:Object):void {		
			var cleanedXML:XML = model.removeNamespaces(event_p.result);			
			//model.materialModel = new MaterialModel(cleanedXML);
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}