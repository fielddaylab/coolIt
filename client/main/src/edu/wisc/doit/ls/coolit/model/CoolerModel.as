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
		
		public var selected:CoolerVO;
		
		private var core:XML;
		private var coolerList:ArrayCollection;
		
		public function CoolerModel(core_p:XML) {
			super();
			core = core_p;
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