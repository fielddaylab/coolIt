package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	import mx.collections.ArrayCollection;
	
	public class MaterialVO implements IValueObject {
		
		private var core:XML;
		private var mpList:ArrayCollection;
		private var itcList:ArrayCollection;
		private var tempCondMap:Object;
		
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
		
		public function get itc():ArrayCollection { 
			if(!itcList) {
				var voList:ArrayCollection = new ArrayCollection();
				for each (var dataPoint:XML in core.IntegratedThermalConductivity.DataPoint) {
					var newDataPoint:DataPointVO = new DataPointVO(dataPoint);
					voList.addItem(newDataPoint);
				}
					
				itcList = voList;
			}
			
			return itcList;
		}
		public function set itc(itc_p:ArrayCollection):void { /* nada */ };
		
		public function getHighestDataValue():Number {
			var arrayList:Array = mp.toArray();
			arrayList.sortOn("data");
			//now get last val
			var maxValue:Number = arrayList[arrayList.length-1];
			
			return maxValue;
		}
		
		public function getConductivityForTemp(temp_p:Number):Number {
			if(!tempCondMap) {
				tempCondMap = new Object();
				var curList:ArrayCollection = itc;
				var itcLen:Number = curList.length;
				for(var i:Number = 0; i<itcLen; i++) {
					var curData:DataPointVO = curList.getItemAt(i) as DataPointVO;
					tempCondMap[curData.temp] = curData.data;
				}
			}
			
			var conductivity:Number;
			if(!tempCondMap[temp_p] || tempCondMap[temp_p] < 0) {
				conductivity = 0;
			} else {
				conductivity = tempCondMap[temp_p];
			}
			
			return conductivity;
		}
		
		public function toString():String {
			return name;
		}
	}
	
}