package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	import mx.collections.ArrayCollection;
	
	public class CoolerVO implements IValueObject {
		
		private var core:XML;
		private var cpmList:ArrayCollection;
		
		public function CoolerVO(core_p:XML) {
			super();
			core = core_p;
		}
		
		public function get name():String { return core.Name; };
		public function set name(name_p:String):void { /* nada */ };
		
		public function get price():Number { return parseFloat(core.price); };
		public function set price(price_p:Number):void { /* nada */ };
		
		public function get priceUnit():String { return core.priceUnit; };
		public function set priceUnit(priceUnit_p:String):void { /* nada */ };
		
		public function get currencyUnit():String { return core.currencyUnit; };
		public function set currencyUnit(currencyUnit_p:String):void { /* nada */ };
		
		public function get cpm():ArrayCollection { 
			if(!cpmList) {
				var voList:ArrayCollection = new ArrayCollection();
				for each (var dataPoint:XML in core.CPM.DataPoint) {
					var newDataPoint:DataPointVO = new DataPointVO(dataPoint);
					voList.addItem(newDataPoint);
				}
				
				cpmList = voList;
			}
			
			return cpmList;
			
		}
		public function set cpm(cpm_p:ArrayCollection):void { /* nada */ };
		
		public function toString():String {
			return name;
		}
	}
	
}