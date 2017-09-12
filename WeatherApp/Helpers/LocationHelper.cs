using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace WeatherApp.Helpers
{
	public static class LocationHelper
	{
		public static async Task<Position> GetLocation()
		{
			try
			{
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;
				var position = await locator.GetPositionAsync(new TimeSpan(10000));
				return position;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
				Position defaultLocation = new Position();
				defaultLocation.Latitude = -23.0000;
				defaultLocation.Longitude = 23.0000;
				return defaultLocation;
			}
		}
	}
}
