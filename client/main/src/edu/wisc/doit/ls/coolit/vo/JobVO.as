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
		
		public var imageURLBase:String;
		public var imageMatrixExtension:String;
		public var videoExtension:String;
		
		private var core:XML;
		private var imageList:ArrayCollection;
		private var requirementList:ArrayCollection;
		
		private var _nestedImageProvider:ArrayCollection;
		
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
		
		public function get fullDescription():String {
			var fullDesc:String = description + "<br /><br /><b>Requirements</b><br />" + getFormattedRequirements();
			return fullDesc; 
		};
		public function set fullDescription(description_p:String):void { /* nada */ };
		
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
		
		public function get baseImageId():String { return core.ImageCollection.BaseURI; };
		public function set baseImageId(url_p:String):void { /* nada */ };
		
		public function get baseImageCollectionId():String { return core.ImageCollection.PickerImageCollection.BaseName; };
		public function set baseImageCollectionId(url_p:String):void { /* nada */ };
		
		public function get introVideoURL():String { return formulateVideoURL(core.ImageCollection.Intro); };
		public function set introVideoURL(url_p:String):void { /* nada */ };
		
		public function get successVideoURL():String { return formulateVideoURL(core.ImageCollection.Success); };
		public function set successVideoURL(url_p:String):void { /* nada */ };
		
		public function get failPowerLimitVideoURL():String { return formulateVideoURL(core.ImageCollection.FailPowerLimit); };
		public function set failPowerLimitVideoURL(url_p:String):void { /* nada */ };
		
		public function get failTooHotVideoURL():String { return formulateVideoURL(core.ImageCollection.FailTooHot); };
		public function set failTooHotVideoURL(url_p:String):void { /* nada */ };
		
		public function get failStrutBreaksVideoURL():String { return formulateVideoURL(core.ImageCollection.FailStrutBreaks); };
		public function set failStrutBreaksVideoURL(url_p:String):void { /* nada */ };
		
		public function get imageCollectionLength():Number { return 5; /* parseInt(core.ImageCollection.PickerImageCollection.Length);*/ };
		public function set imageCollectionLength(length_p:Number):void { /* nada */ };
		
		public function get imageCollectionWidth():Number { return 20; /* parseInt(core.ImageCollection.PickerImageCollection.Width);*/ };
		public function set imageCollectionWidth(length_p:Number):void { /* nada */ };
		
		private function formulateVideoURL(name_p:String):String {
			return imageURLBase + baseImageId + "/" + name_p + "." + videoExtension;
		}
		
		public function get nestedImageProvider():ArrayCollection {
			if(!_nestedImageProvider) {
				_nestedImageProvider = new ArrayCollection();
				
				for(var i:Number = 0; i<imageCollectionLength; i++) {
					var curNum:Number = i;
					var curDir:String = curNum.toString();
					var nestedList:ArrayCollection = new ArrayCollection();
					
					for(var j:Number = 0; j<imageCollectionWidth; j++) {
						var imagePath:String = imageURLBase + baseImageId + "/" + curDir + "/" + baseImageCollectionId + j + "."  +imageMatrixExtension;
						nestedList.addItem(imagePath);
					}
					
					_nestedImageProvider.addItem(nestedList);
				}
			}
			
			return _nestedImageProvider;
		}
		public function set nestedImageProvider(list_p:ArrayCollection):void { /* nada */ };
		
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
		
		public function getFormattedRequirements():String {
			var requirementsList:ArrayCollection = requirements;
			var reqLen:Number = requirementsList.length;
			var tempRequirements:String = "";
			for(var i:Number = 0; i<reqLen; i++) {
				var curReq:RequirementVO = requirementsList.getItemAt(i) as RequirementVO;
				var firstBreak:String = (i == 0) ? "" : "<br />";
				tempRequirements = tempRequirements + firstBreak + "<b>" + curReq.label + "</b> " + curReq.operation + " <b>" + curReq.target + " " + curReq.unit + "</b>";
			}
			
			return tempRequirements;
		}
		
	}
	
}