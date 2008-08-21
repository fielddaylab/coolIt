package edu.wisc.doit.ls.coolit.model {
	
	import mx.collections.ArrayCollection;
	import mx.graphics.Stroke;
	
	[Bindable]
	public class GraphColorModel {
		
		private var colorList:ArrayCollection;
		private var cursor:Number = 0;
		
		public function GraphColorModel() {
			colorList = new ArrayCollection();
			
			//manually add custom color sets as strokes
			colorList.addItem(createNewColorSet(0xCA0202));
			colorList.addItem(createNewColorSet(0x01B101));
			colorList.addItem(createNewColorSet(0x0203C1));
			colorList.addItem(createNewColorSet(0xCAC902));
			colorList.addItem(createNewColorSet(0x02CAC9));
			colorList.addItem(createNewColorSet(0xC902CA));
			colorList.addItem(createNewColorSet(0xD27E02));
			colorList.addItem(createNewColorSet(0x37A637));
			colorList.addItem(createNewColorSet(0x1371FD));
			colorList.addItem(createNewColorSet(0xF4AB02));
			colorList.addItem(createNewColorSet(0xAA56FE));
			colorList.addItem(createNewColorSet(0x7902CA));
			
		}
		
		private function createNewColorSet(color_p:Number):ArrayCollection {
			var stroke1:Stroke = new Stroke();
			stroke1.weight = 2;
			stroke1.color = color_p;
			stroke1.alpha = 0.15;
			
			var stroke2:Stroke = new Stroke();
			stroke2.weight = 1;
			stroke2.color = color_p;
			stroke2.alpha = 0.75;
			
			var newSet:ArrayCollection = new ArrayCollection();
			newSet.addItem(stroke1);
			newSet.addItem(stroke2);
			
			return newSet;
		}
		
		public function getNextColorSet():ArrayCollection {
			var nextSet:ArrayCollection = colorList.getItemAt(cursor) as ArrayCollection;
			if(cursor == (colorList.length-1)) {
				cursor = 0;
			} else {
				cursor = cursor + 1;
			}
			
			return nextSet;
		}
	}
	
}