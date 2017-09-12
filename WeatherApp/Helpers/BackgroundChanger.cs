using System;
namespace WeatherApp.Helpers
{
	public class BackgroundChanger
	{
		public string[] _imageArray = new string[]{"blueearth","circularsun", "dockgreen", "dockmistyshore",
			"earthmoon","fox", "grandcanyon", "lakesky", "lioness", "milkyway", "nightlight", "purple_galaxy",
			"scifiworld", "sky", "sunbehindtree","sunset", "sunsetbehindtree", "sunsetlakerock", "treefrost", 
			"treegreen", "treemiddlelake", "treesunrays", "walle"};

		public string ChangeBackground()
		{
			Random rnd = new Random();
			int imageIndex = rnd.Next(0, _imageArray.Length);
			
			return _imageArray[imageIndex] +".jpg";
		}
	}
}
