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
	public class RunSimulationCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function RunSimulationCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var runSimEvent:RunSimulationEvent = event_p as RunSimulationEvent;
			model = runSimEvent.modelLocator;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.run();
		}
		
		public function result(event_p:Object):void {		
			//set the current data with the current material data
			var cleanedXML:XML = model.removeNamespaces(event_p.result);
			model.inputPower = parseFloat(cleanedXML.RunResult.inputPower);
			model.temperature = parseFloat(cleanedXML.RunResult.temperature);
			model.cost = parseFloat(cleanedXML.RunResult.cost);
			model.stressLimit = parseFloat(cleanedXML.RunResult.stressLimit);
			model.isValidSolution = (cleanedXML.RunResult.isValidSolution.toString().toLowerCase() == "true") ? true : false;
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}