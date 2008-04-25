package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	import mx.collections.ArrayCollection;
	
	public class MaterialVO implements IValueObject {
		
		private var core:XML;
		private var mpList:ArrayCollection;
		
		public function MaterialVO(core_p:XML) {
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
		
		public function get yieldStrength():Number { return parseFloat(core.yieldStrength); };
		public function set yieldStrength(strength_p:Number):void { /* nada */ };
		
		public function get mp():ArrayCollection { 
			if(!mpList) {
				var voList:ArrayCollection = new ArrayCollection();
				for each (var dataPoint:XML in core.MP.DataPoint) {
					var newDataPoint:DataPointVO = new DataPointVO(dataPoint);
					voList.addItem(newDataPoint);
				}
					
				mpList = voList;
			}
			
			return mpList;
		}
		public function set mp(mp_p:ArrayCollection):void { /* nada */ };
		
		public function toString():String {
			return name;
		}
	}
	
}