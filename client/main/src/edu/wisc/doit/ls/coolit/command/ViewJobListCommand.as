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
	public class ViewJobListCommand extends CommonBase implements ICommand {
		
		private var model:CoolItModelLocator;
		
		public function ViewJobListCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var viewJobsEvent:ViewJobListEvent = event_p as ViewJobListEvent;
			model = viewJobsEvent.modelLocator;
			
			var stateModel:StateModel = model.stateModel;
			stateModel.currentState = StateModel.JOB_PICKER;
		}
		
	}
	
}