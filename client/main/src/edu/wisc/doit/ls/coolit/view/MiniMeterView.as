package edu.wisc.doit.ls.coolit.view
{
	import com.adobe.cairngorm.control.*;
	
	import edu.wisc.doit.ls.coolit.model.*;
	
	import mx.containers.Box;
	import mx.containers.Canvas;
	import mx.controls.Label;

	public class MiniMeterView extends Canvas
	{
		public function MiniMeterView():void
		{
			super();
		}

		[Bindable]
		public var valuePassesPoint:Number = 0;
		[Bindable]
		public var dispName:String;
		[Bindable]
		public var inRange:Boolean = false;
		[Bindable]
		public var normalisedWidth:Number = 0;
		[Bindable]
		public var baseWidth:Number = 130;
		private var originalWidth:Number = 0;
		[Bindable]
		public var normalisationFactor:Number = 0;

		// controls
		public var colorBarBackground:Box;
		public var colorBar:Box;
		public var meterLabel:Label;
		public var breakpointMark:Box;
		
		// positioning
		public var posX:Number = 0;
		public var posY:Number = 0;
		
		public function initMeter():void
		{
			// copy baseWidth
			originalWidth = baseWidth;
			
			// position
			this.autoLayout = false;
			this.x = posX;
			this.y = posY;
			
			// generate underlying grey-bar width
			baseWidth = baseWidth - titleOffset();

			// adjust horiz position this much as well
			colorBarBackground.x = titleOffset();
			colorBar.x = titleOffset() + 2;
			
			breakpointMark.x = colorBarBackground.x + valuePassesPoint;
		}

		private function titleOffset():Number
		{
			return meterLabel.width;
		}
	}
}