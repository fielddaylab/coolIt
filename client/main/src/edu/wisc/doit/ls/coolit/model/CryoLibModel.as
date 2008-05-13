package edu.wisc.doit.ls.coolit.model {
	
	import mx.collections.ArrayCollection;
	
	import edu.wisc.doit.ls.coolit.vo.CoolerVO;
	import edu.wisc.doit.ls.coolit.vo.DataPointVO;
	
	[Bindable]
	public class CryoLibModel {
		
		private var specificPower:Object;
		
		public function CryoLibModel() {}
		
		private function getInputPower(temperature_p:Number, outputPower_p:Number):Number {
			if(temperature_p < 2.0 || temperature_p > 300.0) {
				return -1.0;
			}
			
			return (specificPower[temperature_p] as Number) * outputPower_p;
		}
		
		public function initSpecificPowerData(data_p:ArrayCollection):void {
			specificPower = new Object();	// temperature range 0 - 300 K
			specificPower[-1] = 0; // undefined at 0 K
			specificPower[-1] = 1; // undefined at 1 K
			
			// Data file includes values for every 2 deg in the range 2 - 300, fill in those values
			var dataLen:Number = data_p.length;
			for(var i:Number = 0; i<dataLen; i++) {
				var curData:DataPointVO = data_p.getItemAt(i) as DataPointVO;
				
				if(i > 1) {
					specificPower[curData.temp] = curData.data;
				}
			}
			
			// Use averaging to fill in all the odd numbered values
			for (var i:Number = 2; i < 300; i++) {
				var curValue:Number = specificPower[i] as Number;
				var nextValue:Number = specificPower[i+1] as Number;
				var prevValue:Number = specificPower[i-1] as Number;
				
				if (curValue == 0.0) {
					specificPower[i] = (prevValue + nextValue) / 2.0;
				}
			}
			
		}
		
		public function calculateOutputPower(temperature_p:Number, powerFactor_p:Number, cooler_p:CoolerVO):Number {
			var dataPoint1:DataPointVO = cooler_p.cpm.getItemAt(0) as DataPointVO;
			var dataPoint2:DataPointVO = cooler_p.cpm.getItemAt(1) as DataPointVO;
			var x1:Number = dataPoint1.temp;
			var y1:Number = dataPoint1.data;
			var x2:Number = dataPoint2.temp;
			var y2:Number = dataPoint2.data;
			var x:Number = temperature_p;
			var y:Number = y1 + ((x - x1)*(y2 - y1) / (x2 - x1));
			var powerFactoredY:Number = y - (dataPoint2.data * (1 - powerFactor_p));
			if( powerFactoredY < 0 ) {
				return 0;
			} else {
				return powerFactoredY;
			}
		}
		
		public function calculateInputPower(temperature_p:Number, powerFactor_p:Number, cooler_p:CoolerVO):Number {
			var outputPower:Number = calculateOutputPower(temperature_p, powerFactor_p, cooler_p);
			
			var answer:Number = getInputPower(temperature_p, outputPower);
			
			return answer;
		}
	}
	
}