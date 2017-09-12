using System;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherApp.Converters
{
	public class AppendDegreeCharacter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int temp = (int)Math.Round((double)value);
			return temp.ToString() + "º";

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.ToString();
		}
	}
}