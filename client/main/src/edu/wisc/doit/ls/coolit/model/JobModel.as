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
		
		public var selectedJob:JobVO;
		
		private var core:ArrayCollection;
		private var jobList:ArrayCollection;
		
		public function JobModel(core_p:ArrayCollection) {
			super();
			if(!core_p) {
				core = new ArrayCollection();
			} else {
				core = core_p;
			}
		}
		
		public function get jobs():ArrayCollection {
			if(!jobList) {
				jobList = convertToJobVOs(core);
				selectedJob = jobList.getItemAt(0) as JobVO;
			}
			
			return jobList;
		}
		
		public function set jobs(jobs_p:ArrayCollection):void {
			//do nada
		}
		
		private function convertToJobVOs(list_p:ArrayCollection):ArrayCollection {
			var voList:ArrayCollection = new ArrayCollection();
			var ogLen:Number = list_p.length;
			for(var i:Number = 0; i<ogLen; i++) {
				var currentJob:Object = list_p.getItemAt(i) as Object;
				var newJob:JobVO = new JobVO(currentJob);
				voList.addItem(newJob);
			}
			
			return voList;
		}
		
    }
}