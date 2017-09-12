using System;
using Xamarin.Forms;

namespace WeatherApp.Controls
{
	public class WeatherLabel : Label
	{
		public static readonly BindableProperty LabelFontProperty =
		BindableProperty.Create(
			"LabelFont",
			typeof(string),
			typeof(WeatherLabel),
			default(string));

		public string LabelFont
		{
			get { return (string)GetValue(LabelFontProperty); }
			set { SetValue(LabelFontProperty, value); }
		}
	}
}
