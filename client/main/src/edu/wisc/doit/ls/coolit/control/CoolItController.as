package edu.wisc.doit.ls.coolit.control {
	
	import com.adobe.cairngorm.control.FrontController;
	import edu.wisc.doit.ls.coolit.command.*
	import edu.wisc.doit.ls.coolit.event.*;
	
	/**
	 * 
	 */
	public class CoolItController extends FrontController {
		public function CoolItController() {
			initialiseCommands();
		}
		
		public function initialiseCommands():void {
			addCommand(ChooseJobEvent.EVENT_CHOOSE_JOB, ChooseJobCommand);
			addCommand(GetJobListEvent.EVENT_GET_JOB_LIST, GetJobListCommand);
			addCommand(ViewJobListEvent.EVENT_VIEW_JOB_LIST, ViewJobListCommand);
			addCommand(GetCoolerListEvent.EVENT_GET_COOLER_LIST, GetCoolerListCommand);
			addCommand(SetCoolerEvent.EVENT_SET_COOLER, SetCoolerCommand);
			addCommand(GetMaterialListEvent.EVENT_GET_MATERIAL_LIST, GetMaterialListCommand);
			addCommand(GetInputPowerDataEvent.EVENT_GET_INPUT_POWER, GetInputPowerDataCommand);
			addCommand(GetOutputPowerDataEvent.EVENT_GET_OUTPUT_POWER, GetOutputPowerDataCommand);
			addCommand(SetStrutEvent.EVENT_SET_STRUT, SetStrutCommand);
			addCommand(RunSimulationEvent.EVENT_RUN_SIM, RunSimulationCommand);
			addCommand(CommitSolutionEvent.EVENT_COMMIT_SOLUTION, CommitSolutionCommand);
			addCommand(SetProblemEvent.EVENT_SET_PROBLEM, SetProblemCommand);
			addCommand(GetSpecificPowerDataEvent.EVENT_GET_POWER, GetSpecificPowerDataCommand);
			addCommand(ChangeWorkAreaStateEvent.EVENT_CHANGE_WORK_STATE, ChangeWorkAreaStateCommand);
			addCommand(ProcessPowerFactorEvent.EVENT_PROCESS_POWER_FACTOR, ProcessPowerFactorCommand);
			addCommand(LoginEvent.EVENT_LOGIN, LoginCommand);
			addCommand(EnterCutScreenEvent.EVENT_ENTER_CUT, EnterCutScreenCommand);
			addCommand(LeaveCutScreenEvent.EVENT_LEAVE_CUT, LeaveCutScreenCommand);
			addCommand(UpdateStateCaptureEvent.EVENT_UPDATE_CAPTURE, UpdateStateCaptureCommand);
			addCommand(AddNewStateCaptureEvent.EVENT_ADD_CAPTURE, AddNewStateCaptureCommand);
			addCommand(RemoveStateCaptureEvent.EVENT_REMOVE_CAPTURE, RemoveStateCaptureCommand);
			addCommand(SelectStateCaptureEvent.EVENT_SELECT_CAPTURE, SelectStateCaptureCommand);
			addCommand(SetSimulationModeEvent.EVENT_SET_SIM_MODE, SetSimulationModeCommand);
			addCommand(GetFeedbackEvent.EVENT_GET_FEEDBACK, GetFeedbackCommand);
			addCommand(ClearStateCapturesEvent.EVENT_CLEAR_CAPTURES, ClearStateCapturesCommand);
		}	
	}
	
}