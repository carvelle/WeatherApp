using Foundation;
using UIKit;
using WeatherApp.Controls;
using WeatherApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WeatherLabel), typeof(IOSWeatherLabel))]
namespace WeatherApp.iOS.Renderers
{
	public class IOSWeatherLabel : LabelRenderer
	{

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var font = ((WeatherLabel)sender).FontFamily;
			var fontSize = ((WeatherLabel)sender).FontSize;

			if (!string.IsNullOrEmpty(font))
			{
				if (Control != null)
				{
					Control.Font = UIFont.FromName("HelveticaNeue-Thin", (System.nfloat)fontSize);
				}
			}
		}

	}
}

