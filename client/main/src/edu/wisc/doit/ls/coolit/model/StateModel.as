package edu.wisc.doit.ls.coolit.model {
	
	[Bindable]
	public class StateModel {
		public static var JOB_PICKER:String = "jobPicker";
		public static var JOB_SCREEN:String = "jobScreen";
		public static var COMPONENT_STATE:String = "componentState";
		public static var SKETCH_STATE:String = "sketchState";
		
		public static var POWER_FACTOR:String = "powerFactorState";
		public static var STRUT_LENGTH:String = "strutLengthState";
		public static var STRUT_CROSS_SECTION:String = "strutCrossSectionState";
		
		public var currentState:String;
		public var sketchState:String = POWER_FACTOR;
		public var workAreaState:String = COMPONENT_STATE;
		
		public function StateModel() {
			currentState = StateModel.JOB_PICKER;
		}
		
	}
	
}