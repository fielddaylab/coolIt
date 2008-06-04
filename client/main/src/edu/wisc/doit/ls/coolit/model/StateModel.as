package edu.wisc.doit.ls.coolit.model {
	
	[Bindable]
	public class StateModel {
		public static var LOGIN_SCREEN:String = "login";
		public static var JOB_PICKER:String = "jobPicker";
		public static var JOB_SCREEN:String = "jobScreen";
		public static var COMPONENT_STATE:String = "componentState";
		public static var SKETCH_STATE:String = "sketchState";
		public static var CUT_SCREEN_STATE:String = "cutScreen";
		
		public static var POWER_FACTOR:String = "powerFactorState";
		public static var STRUT_LENGTH:String = "strutLengthState";
		public static var STRUT_CROSS_SECTION:String = "strutCrossSectionState";
		
		public var currentState:String;
		public var sketchState:String = POWER_FACTOR;
		public var workAreaState:String = COMPONENT_STATE;
		public var afterCutState:String;
		
		public var currentCutSource:*;
		
		public function StateModel() {
			currentState = StateModel.LOGIN_SCREEN;
		}
		
	}
	
}