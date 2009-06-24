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
		
		//sim modes
		public static var GEOMETRY_SIM:String = "geometrySim";
		public static var GRAPH_SIM:String = "graphSim";
		
		//login states
		public static var SIGNED_OUT:String = "signedOut";
		public static var LOGGED_IN:String = "loggedIn";
		public static var INVALID_LOGIN:String = "invalidLogin";
		public static var ANON_LOGIN:String = "anonymousLogin";
		
		public var simulationMode:String = GEOMETRY_SIM;
		
		public var currentState:String;
		public var sketchState:String = POWER_FACTOR;
		public var workAreaState:String = COMPONENT_STATE;
		public var afterCutState:String;
		
		public var loginState:String = SIGNED_OUT;
		
		public var currentCutSource:*;
		
		//manages if services are out
		public var setStrutCommandOut:Boolean = false;
		
		public function StateModel() {
			currentState = StateModel.LOGIN_SCREEN;
		}
		
	}
	
}