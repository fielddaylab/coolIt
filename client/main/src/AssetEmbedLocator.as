package {
	
	public class AssetEmbedLocator {
		
		[Embed(source="../skin/images/temp_image.png")] public static var tempImage:Class;
		[Embed(source="../skin/images/open_arrow.swf")] public static var openArrow:Class;
		[Embed(source="../skin/images/closed_arrow.swf")] public static var closedArrow:Class;
		[Embed(source="../skin/images/thermal_text.swf")] public static var thermalText:Class;
		[Embed(source="../skin/images/temp_text.swf")] public static var tempText:Class;
		[Embed(source="../skin/images/output_cooling_power.swf")] public static var outputText:Class;
		[Embed(source="../skin/images/input_cooling_power.swf")] public static var inputText:Class;
		
		public function AssetEmbedLocator() {}
		
	}
	
}