using System;
using Android.Widget;
using WeatherApp.Droid.Utilities;
using WeatherApp.Controls;
using WeatherApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WeatherLabel), typeof(DroidWeatherLabel))]
namespace WeatherApp.Droid.Renderers
{
	public class DroidWeatherLabel : LabelRenderer
	{
		private object _xamFormsSender;

		public DroidWeatherLabel()
		{
			_xamFormsSender = null;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
			Label label = e.NewElement;
			if (label == null)
				return;

		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (_xamFormsSender != sender || e.PropertyName == WeatherLabel.FontFamilyProperty.PropertyName)
			{
				var font = ((WeatherLabel)sender).FontFamily;
				var fontSize = ((WeatherLabel)sender).FontSize;

				if (!string.IsNullOrEmpty(font))
				{
					var typeface = MainApplication.GetCustomTypeFace(font);

					var label = Control as TextView;
					if (label != null)
					{
						label.Typeface = typeface;
						label.SetTextSize(Android.Util.ComplexUnitType.Dip, PixelUtils.ConvertDpToPixels(Convert.ToSingle(fontSize)));
					}
				}
				_xamFormsSender = sender;
			}
		}


	}
}
