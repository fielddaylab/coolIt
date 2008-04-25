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
		}	
	}
	
}