package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	import mx.collections.ArrayCollection;
	
	public class JobVO implements IValueObject {
		
		private var core:XML;
		private var imageURLBase:String = "http://atswindev.doit.wisc.edu/CoolIt_Service/images/";
		private var imageList:ArrayCollection;
		
		public function JobVO(core_p:XML) {
			super();
			core = core_p;
		}
		
		public function get name():String { return core.@Name; };
		public function set name(name_p:String):void { /* nada */ };
		
		public function get description():String { return core.Description; };
		public function set description(description_p:String):void { /* nada */ };
		
		public function get pay():Number { return parseFloat(core.MonetaryIncentive); };
		public function set pay(pay_p:Number):void { /* nada */ };
		
		public function get heatLeak():Number { return parseFloat(core.HeatLeak); };
		public function set heatLeak(heat_p:Number):void { /* nada */ };
		
		public function get supportMode():String { return core.SupportMode; };
		public function set supportMode(mode_p:String):void { /* nada */ };
		
		public function get minimumStrutLength():Number { return parseFloat(core.MinStrutLength); };
		public function set minimumStrutLength(length_p:Number):void { /* nada */ };
		
		public function get maximumStrutLength():Number { return parseFloat(core.MaxStrutLength); };
		public function set maximumStrutLength(length_p:Number):void { /* nada */ };
		
		public function get supportNumber():Number { return parseFloat(core.SupportNumber); };
		public function set supportNumber(length_p:Number):void { /* nada */ };
		
		public function get solved():Boolean { return (core.Solved.toLowerCase() == "true") ? true : false; };
		public function set solved(solved_p:Boolean):void { /* nada */ };
		
		public function get images():ArrayCollection { 
			if(!imageList) {
				var voList:ArrayCollection = new ArrayCollection();
				for each (var dataPoint:XML in core.Images.string) {
					var imageURL:String = imageURLBase + dataPoint.toString();
					voList.addItem(imageURL);
				}
					
				imageList = voList;
			}
			
			return imageList;
			
		}
		public function set images(images_p:ArrayCollection):void { /* nada */ };
		
		public function getImageAt(index_p:Number):String {
			var curImages:ArrayCollection = images;
			var curURL:String = curImages.getItemAt(index_p) as String;
			
			return curURL;
		}
		
		public function toString():String {
			return name;
		}
	}
	
}