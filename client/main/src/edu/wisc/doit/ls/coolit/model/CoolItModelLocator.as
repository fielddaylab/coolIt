package edu.wisc.doit.ls.coolit.model {
	import com.adobe.cairngorm.model.ModelLocator;
	
	import edu.wisc.doit.ls.coolit.*;
	import edu.wisc.doit.ls.coolit.model.*;
	
	import mx.collections.ArrayCollection;
	
	[Bindable]
	public class CoolItModelLocator implements ModelLocator {
		private static var modelLocator:CoolItModelLocator;
		
		public var jobModel:JobModel;
		
		public static function getInstance():CoolItModelLocator {
			if(modelLocator == null) {
				modelLocator = new CoolItModelLocator();
			}
      		
			return modelLocator;
		}
		
		public function CoolItModelLocator() {	
			if(modelLocator != null) {
				throw new Error( "Only one CoolItModelLocator instance should be instantiated" );	
			}
			
		}
		
	}
}