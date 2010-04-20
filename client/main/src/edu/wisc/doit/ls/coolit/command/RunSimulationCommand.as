package edu.wisc.doit.ls.coolit.command
{
	import flash.utils.*;
	import mx.rpc.IResponder;
	
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.*;
	
	import edu.wisc.doit.ls.coolit.model.*;
	import edu.wisc.doit.ls.coolit.event.*;
	import edu.wisc.doit.ls.coolit.business.*;
	import edu.wisc.doit.ls.coolit.vo.*;
	import edu.wisc.doit.ls.coolit.CommonBase;
	
	import mx.collections.ArrayCollection;
	
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
			
			model.servicesOut++;
			model.runSimCount++;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.run();
		}
		
		public function result(event_p:Object):void {
			var stateModel:StateModel = model.stateModel;
			var jobModel:JobModel = model.jobModel;
			
			model.runSimCount--;
			model.servicesOut--;
			//set the current data with the current material data
			var cleanedXML:XML = model.removeNamespaces(event_p.result);
			model.inputPower = parseFloat(cleanedXML.RunResult.inputPower);
			model.temperature = parseFloat(cleanedXML.RunResult.temperature);
			model.cost = parseFloat(cleanedXML.RunResult.cost);
			model.stressLimit = parseFloat(cleanedXML.RunResult.stressLimit);
			model.isValidSolution = (cleanedXML.RunResult.isValidSolution.toString().toLowerCase() == "true") ? true : false;
			
			//check for valid ranges
			//first get current jobs requirements list
			var requirements:ArrayCollection = jobModel.selected.requirements;
			var reqLen:Number = requirements.length;
			var powerInRange:Boolean = true;
			var tempInRange:Boolean = true;
			var strengthInRange:Boolean = true;
			for(var i:Number = 0; i<reqLen; i++) {
				var curReq:RequirementVO = requirements.getItemAt(i) as RequirementVO;
				
				switch(curReq.value) {
					case RequirementVO.FORCE_LIMIT:
						var forceLimitPassed:Boolean = curReq.valuePasses(model.stressLimit);
						//trace("forceLimitPassed: " + forceLimitPassed);
						if(!forceLimitPassed) {
							strengthInRange = false;
						}
						break;
					case RequirementVO.INPUT_POWER:
						var inputPowerPassed:Boolean = curReq.valuePasses(model.inputPower);
						//trace("inputPowerPassed: " + inputPowerPassed + " model.inputPower*1000: " + model.inputPower*1000);
						if(!inputPowerPassed) {
							powerInRange = false;
						}
						break;
					case RequirementVO.TEMP:
						var tempPassed:Boolean = curReq.valuePasses(model.temperature);
						//trace("tempPassed: " + tempPassed);
						if(!tempPassed) {
							tempInRange = false;
						}
						break;
					default:
						break;
				}
			}
			
			jobModel.powerInRange = powerInRange;
			jobModel.tempInRange = tempInRange;
			jobModel.strengthInRange = strengthInRange;
			//model.updateSketchData();
			if(model.runSimCount == 0 && stateModel.simulationMode == StateModel.GRAPH_SIM) {
				dispatchUpdateStateCapture();
			}
			//log.fatal("{0} - model.temperature: " + model.temperature, getQualifiedClassName(this) + ".fault");
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			model.runSimCount--;
			model.servicesOut--;
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
		public function dispatchUpdateStateCapture():void {
			var updateCapture:UpdateStateCaptureEvent = new UpdateStateCaptureEvent();
			updateCapture.modelLocator = model;
			CairngormEventDispatcher.getInstance().dispatchEvent(updateCapture);
		}
	}
	
}