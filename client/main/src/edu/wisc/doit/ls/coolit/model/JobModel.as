package edu.wisc.doit.ls.coolit.model {
	import flash.events.*;
	import flash.utils.*;
	
	import mx.events.*;
	
	import mx.collections.ArrayCollection;
	
	import edu.wisc.doit.ls.coolit.vo.JobVO;
	
	import edu.wisc.doit.ls.coolit.CommonBase;
	
	/*
	 *  Wraps a GetProblemsResponse object
	 *
	 *  @author Ben Longoria
	 */
    [Bindable] public class JobModel extends CommonBase {
		
		public var selected:JobVO;
		
		public var imageURLBase:String;
		public var imageMatrixExtension:String;
		public var videoExtension:String;
		
		public var finishCutURL:String;
		
		public var tempInRange:Boolean;
		public var strengthInRange:Boolean;
		public var powerInRange:Boolean;
		
		private var core:XML;
		private var jobList:ArrayCollection;
		
		public function JobModel(core_p:XML) {
			super();
			core = core_p;
		}
		
		public function get jobs():ArrayCollection {
			if(!jobList) {
				jobList = convertToJobVOs(core);
				selected = jobList.getItemAt(0) as JobVO;
			}
			
			return jobList;
		}
		
		public function set jobs(jobs_p:ArrayCollection):void {
			//do nada
		}
		
		private function convertToJobVOs(core_p:XML):ArrayCollection {
			var voList:ArrayCollection = new ArrayCollection();
			for each (var job:XML in core_p.GetProblemsResult.Problem) {
				var newJob:JobVO = new JobVO(job);
				newJob.imageURLBase = imageURLBase;
				newJob.imageMatrixExtension = imageMatrixExtension;
				newJob.videoExtension = videoExtension;
				voList.addItem(newJob);
			}
			
			return voList;
		}
		
    }
}