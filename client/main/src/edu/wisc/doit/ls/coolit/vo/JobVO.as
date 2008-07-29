package edu.wisc.doit.ls.coolit.vo {
	import com.adobe.cairngorm.vo.IValueObject;
	
	import mx.collections.ArrayCollection;
	
	public class JobVO implements IValueObject {
		public static var STRUT_LENGTH:String = "STRUT_LENGTH";
		public static var STRUT_CROSS_SECTION:String = "STRUT_CROSS_SECTION";
		public static var FORCE_LIMIT:String = "FORCE_LIMIT";
		public static var INPUT_POWER:String = "INPUT_POWER";
		public static var GREATER_THAN_OR_EQUAL:String = "GE";
		public static var LESS_THAN_OR_EQUAL:String = "LE";
		
		private var core:XML;
		private var imageURLBase:String = "http://atswindev.doit.wisc.edu/CoolIt_Service/images/";
		private var imageList:ArrayCollection;
		private var requirementList:ArrayCollection;
		
		private var _strutLengthMin:Number;
		private var _strutLengthMax:Number;
		private var _strutCrossSectionMax:Number;
		private var _forceLimit:Number;
		private var _inputPower:Number;
		
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
		
		public function get image():String {
			var imageList:ArrayCollection = images;
			return images.getItemAt(0) as String;
		}
		public function set image(images_p:String):void { /* nada */ };
		
		public function get images():ArrayCollection { 
			if(!imageList) {
				var voList:ArrayCollection = new ArrayCollection();
				for each (var dataPoint:XML in core.Images.string) {
					var imageURL:String;
					var tempURL:String = dataPoint.toString();
					if(tempURL == "2.18.08 Minesweeper.JPG") {
						imageURL = "./minesweeper.jpg";
					} else {
						imageURL = imageURLBase + tempURL;
					}
					
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
		
		public function get requirements():ArrayCollection { 
			if(!requirementList) {
				var voList:ArrayCollection = new ArrayCollection();
				for each (var dataPoint:XML in core.Constraints.Constraint) {
					var newReq:RequirementVO = new RequirementVO(dataPoint);
					voList.addItem(newReq);
				}
				requirementList = voList;
			}
			
			return requirementList;
			
		}
		public function set requirements(reqs_p:ArrayCollection):void { /* nada */ };
		
		public function get strutLengthMin():Number { 
			if(!_strutLengthMin) {
				for each (var dataPoint:XML in core.Constraints.Constraint) {
					var curValue:String = dataPoint.@Value.toString();
					var curOp:String = dataPoint.@Op.toString();
					var curTarget:Number = parseFloat(dataPoint.@Target);
					if(curValue == STRUT_LENGTH && curOp == GREATER_THAN_OR_EQUAL) {
						_strutLengthMin = curTarget;
						break;
					}
				}
			}
			
			return _strutLengthMin;
			
		}
		public function set strutLengthMin(value_p:Number):void { /* nada */ };
		
		public function get strutLengthMax():Number { 
			if(!_strutLengthMax) {
				for each (var dataPoint:XML in core.Constraints.Constraint) {
					var curValue:String = dataPoint.@Value.toString();
					var curOp:String = dataPoint.@Op.toString();
					var curTarget:Number = parseFloat(dataPoint.@Target);
					if(curValue == STRUT_LENGTH && curOp == LESS_THAN_OR_EQUAL) {
						_strutLengthMax = curTarget;
						break;
					}
				}
			}
			
			return _strutLengthMax;
			
		}
		public function set strutLengthMax(value_p:Number):void { /* nada */ };
		
		public function get strutCrossSectionMax():Number { 
			if(!_strutCrossSectionMax) {
				for each (var dataPoint:XML in core.Constraints.Constraint) {
					var curValue:String = dataPoint.@Value.toString();
					var curOp:String = dataPoint.@Op.toString();
					var curTarget:Number = parseFloat(dataPoint.@Target);
					if(curValue == STRUT_CROSS_SECTION && curOp == LESS_THAN_OR_EQUAL) {
						_strutCrossSectionMax = curTarget;
						break;
					}
				}
			}
			
			return _strutCrossSectionMax;
			
		}
		public function set strutCrossSectionMax(value_p:Number):void { /* nada */ };
		
		public function get forceLimit():Number { 
			if(!_forceLimit) {
				for each (var dataPoint:XML in core.Constraints.Constraint) {
					var curValue:String = dataPoint.@Value.toString();
					var curTarget:Number = parseFloat(dataPoint.@Target);
					if(curValue == FORCE_LIMIT) {
						_forceLimit = curTarget;
						break;
					}
				}
			}
			
			return _forceLimit;
			
		}
		public function set forceLimit(value_p:Number):void { /* nada */ };
		
		public function get inputPower():Number { 
			if(!_inputPower) {
				for each (var dataPoint:XML in core.Constraints.Constraint) {
					var curValue:String = dataPoint.@Value.toString();
					var curTarget:Number = parseFloat(dataPoint.@Target);
					if(curValue == INPUT_POWER) {
						_inputPower = curTarget;
						break;
					}
				}
					}
			
			return _inputPower;
			
		}
		public function set inputPower(value_p:Number):void { /* nada */ };
		
		public function toString():String {
			return name;
		}
	}
	
}