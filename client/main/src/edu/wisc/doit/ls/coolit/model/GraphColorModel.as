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
			colorList.addItem(createNewColorSet(0xFF0000));
			colorList.addItem(createNewColorSet(0x00FF00));
			colorList.addItem(createNewColorSet(0x0000FF));
			colorList.addItem(createNewColorSet(0xFFFF00));
			colorList.addItem(createNewColorSet(0x00FFFF));
			colorList.addItem(createNewColorSet(0xFF00FF));
			colorList.addItem(createNewColorSet(0xFF9900));
			colorList.addItem(createNewColorSet(0x66CC66));
			colorList.addItem(createNewColorSet(0x6699FF));
			colorList.addItem(createNewColorSet(0xFFCC33));
			colorList.addItem(createNewColorSet(0xCC99FF));
			colorList.addItem(createNewColorSet(0x9900FF));
			
		}
		
		private function createNewColorSet(color_p:Number):ArrayCollection {
			var stroke1:Stroke = new Stroke();
			stroke1.weight = 2;
			stroke1.color = color_p;
			stroke1.alpha = 0.20;
			
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