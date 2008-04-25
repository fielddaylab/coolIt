package edu.wisc.doit.ls.coolit.model {
	import flash.events.*;
	import flash.utils.*;
	
	import mx.events.*;
	
	import mx.collections.ArrayCollection;
	
	import edu.wisc.doit.ls.coolit.vo.MaterialVO;
	
	import edu.wisc.doit.ls.coolit.CommonBase;
	
	/*
	 *  Wraps a GetMaterialsResponse object
	 *
	 *  @author Ben Longoria
	 */
    [Bindable] public class MaterialModel extends CommonBase {
		
		public var selected:MaterialVO;
		
		private var core:XML;
		private var materialList:ArrayCollection;
		
		public function MaterialModel(core_p:XML) {
			super();
			core = core_p;
		}
		
		public function get materials():ArrayCollection {
			if(!materialList) {
				materialList = convertToMaterialVOs(core);
				selected = materialList.getItemAt(0) as MaterialVO;
			}
			
			return materialList;
		}
		
		public function set materials(materials_p:ArrayCollection):void {
			//do nada
		}
		
		private function convertToMaterialVOs(core_p:XML):ArrayCollection {
			var voList:ArrayCollection = new ArrayCollection();
			for each (var material:XML in core_p.GetMaterialsResult.Material) {
				var newMaterial:MaterialVO = new MaterialVO(material);
				voList.addItem(newMaterial);
			}
			return voList;
		}
		
    }
}