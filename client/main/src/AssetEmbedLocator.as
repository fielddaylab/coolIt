package {
	
	public class AssetEmbedLocator {
		
		[Embed(source="../skin/images/temp_image.png")] public static var tempImage:Class;
		[Embed(source="../skin/images/open_arrow.swf")] public static var openArrow:Class;
		[Embed(source="../skin/images/closed_arrow.swf")] public static var closedArrow:Class;
		
		public function AssetEmbedLocator() {}
		
	}
	
}