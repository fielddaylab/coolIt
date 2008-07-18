package edu.wisc.doit.ls.coolit.model {
	import flash.events.*;
	import flash.utils.*;
	
	import mx.events.*;
	
	import mx.collections.ArrayCollection;
	
	import edu.wisc.doit.ls.coolit.vo.CoolerVO;
	
	import edu.wisc.doit.ls.coolit.CommonBase;
	
	/*
	 *  Wraps a GetCoolersResponse object
	 *
	 *  @author Ben Longoria
	 */
    [Bindable] public class CoolerModel extends CommonBase {
		public static const INPUT_POWER:String = "inputPowerData";
		public static const OUTPUT_POWER:String = "outputPowerData";
		public static const DEFAULT_POWER_FACTOR:Number = 1;
		
		public var selected:CoolerVO;
		public var currentData:ArrayCollection;
		public var outputPowerData:ArrayCollection;
		public var tempMax:Number = 300;
		public var inputPowerMax:Number = 300;
		public var outputPowerMax:Number = 300;
		public var currentPowerMax:Number = 300;
		
		public var defaultPowerFactor:Number = DEFAULT_POWER_FACTOR;
		public var defaultPowerSetting:String = OUTPUT_POWER;
		
		private var core:XML;
		private var coolerList:ArrayCollection;
		
		public function CoolerModel(core_p:XML) {
			super();
			core = core_p;
			currentData = new ArrayCollection();
		}
		
		public function get coolers():ArrayCollection {
			if(!coolerList) {
				coolerList = convertToCoolerVOs(core);
				selected = coolerList.getItemAt(0) as CoolerVO;
			}
			
			return coolerList;
		}
		
		public function set coolers(coolers_p:ArrayCollection):void {
			//do nada
		}
		
		private function convertToCoolerVOs(core_p:XML):ArrayCollection {
			var voList:ArrayCollection = new ArrayCollection();
			for each (var cooler:XML in core_p.GetCoolersResult.Cooler) {
				var newCooler:CoolerVO = new CoolerVO(cooler);
				voList.addItem(newCooler);
			}
			return voList;
		}
		
    }
}