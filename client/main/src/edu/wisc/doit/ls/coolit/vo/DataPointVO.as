package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
		
	public class DataPointVO implements IValueObject {
		
		private var core:XML;
		
		public function DataPointVO(core_p:XML) {
			super();
			core = core_p;
		}
		
		public function get temp():Number { return parseFloat(core.temp); };
		public function set temp(temp_p:Number):void { /* nada */ };
		
		public function get data():Number { return parseFloat(core.data); };
		public function set data(data_p:Number):void { core.data = data_p.toString(); };
		
		public function get chartData():Object {
			var curData:Object = new Object();
			curData.id = temp.toString() + data.toString();
			curData.temp = temp;
			curData.data = data;
			
			return curData;
		}
		public function set chartData(data_p:Object):void {};
		
		public function toString():String {
			return "(" + temp + "," + data + ")";
		}
	}
	
}