package edu.wisc.doit.ls.coolit.model {
	
	[Bindable]
	public class StateModel {
		public static var JOB_PICKER:String = "jobPicker";
		public static var JOB_SCREEN:String = "jobScreen";
		
		public var currentState:String;
		
		public function StateModel() {
			currentState = StateModel.JOB_PICKER;
		}
		
	}
	
}