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
	public class GetFeedbackCommand extends CommonBase implements ICommand, IResponder {
		
		private var model:CoolItModelLocator;
		
		public function GetFeedbackCommand() {
			super();
		}
		
		public function execute(event_p:CairngormEvent):void {
			var getFeedbackEvent:GetFeedbackEvent = event_p as GetFeedbackEvent;
			model = getFeedbackEvent.modelLocator;
			
			model.servicesOut++;
			
			var delegate:CoolItDelegate = new CoolItDelegate(this);
			delegate.getFeedback();
		}
		
		public function result(event_p:Object):void {
			model.servicesOut--;
			//set the current data with the current material data
			var cleanedXML:XML = model.removeNamespaces(event_p.result);
			var jobModel:JobModel = model.jobModel;
			
			var feedbackVO:FeedbackVO = new FeedbackVO(cleanedXML);
			jobModel.currentFeedback = feedbackVO;
			jobModel.finishCutURL = null;
			var curScreenURL:String;
			switch(feedbackVO.cutScreen) {
				case FeedbackVO.SUCCESS:
					jobModel.finishCutURL = jobModel.selected.successVideoURL;
					break;
				case FeedbackVO.POWER_LIMIT:
					jobModel.finishCutURL = jobModel.selected.failPowerLimitVideoURL;
					break;
				case FeedbackVO.TOO_HOT:
					jobModel.finishCutURL = jobModel.selected.failTooHotVideoURL;
					break;
				case FeedbackVO.STRUT_BREAKS:
					jobModel.finishCutURL = jobModel.selected.failStrutBreaksVideoURL;
					break;
			}
			//trace(cleanedXML);
			trace(feedbackVO.text);
			trace(feedbackVO.cutScreen);
			/*
			currentFeedback 
			 public static var SUCCESS:String = "Success";
			 public static var POWER_LIMIT:String = "PowerLimitExceeded";
			 public static var TOO_HOT:String = "TooHot";
			 public static var STRUT_BREAKS:String = "StrutBreaks";
			 
			*/
		}
		
		public function fault(event_p:Object):void {
			//log failure here
			log.fatal("{0} - " + event_p.toString(), getQualifiedClassName(this) + ".fault");
		}
		
	}
	
}