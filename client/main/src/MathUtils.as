package {
	/**
	 * Utility functions for the manipulation of numbers.
	 */
	public class MathUtils
		{
			/**
			 * Rounds a target number to the nearest multiple of another number.
			 * @see Math#round
			 */
			public static function roundToNearest(numberToRound:Number, nearest:Number):Number
			{
				return Math.round(numberToRound / nearest) * nearest;
			}
			/**
			 * Rounds a target number up to the nearest multiple of another number.
			 * @see Math#ceil
			 */
			public static function roundUpToNearest(numberToRound:Number, nearest:Number):Number
			{
				return Math.ceil(numberToRound / nearest) * nearest;
			}
			/**
			 * Rounds a target number down to the nearest multiple of another number.
			 * @see Math#floor
			 */
			public static function roundDownToNearest(numberToRound:Number, nearest:Number):Number
			{
				return Math.floor(numberToRound / nearest) * nearest;
			}
			/**
			 * Rounds a target number to a specific number of decimal places.
			 * @see Math#round
			 */
			public static function roundToPrecision(number:Number, precision:int = 0):Number
			{
				var decimalPlaces:Number = Math.pow(10, precision);
				return Math.round(decimalPlaces * number) / decimalPlaces;
			}
		}
}
/*
 Copyright (c) 2007 Josh Tynjala
 Permission is hereby granted, free of charge, to any person
 obtaining a copy of this software and associated documentation
 files (the "Software"), to deal in the Software without
 restriction, including without limitation the rights to use,
 copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the
 Software is furnished to do so, subject to the following
 conditions:
 The above copyright notice and this permission notice shall be
 included in all copies or substantial portions of the Software.
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 OTHER DEALINGS IN THE SOFTWARE.
 */