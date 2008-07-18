package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	public class DataShotVO implements IValueObject {
		
		public var temperature:Number;
		public var coolingOutputWatts:Number;
		public var heatLeakWatts:Number;
		
		public function DataShotVO() {}
		
	}
	
}