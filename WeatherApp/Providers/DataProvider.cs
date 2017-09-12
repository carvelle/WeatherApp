using System.Net.Http;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;
using WeatherApp.Extensions;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Network;

namespace WeatherApp
{
	public class DataProvider : BaseConnectivityManager, IDataProvider
	{
		public async Task<CurrentWeatherModel> GetCurrentWeather(Position latlng)
		{
			if (latlng == null)
				return null;
			string latitude = latlng.Latitude.ToString();
			string longitude = latlng.Longitude.ToString();
			string weatherUrl = Urls.CurrentWeatherUrl.AppendCoordinates(latitude, longitude, Constants.APPID);
			return await WrapHttpCall<CurrentWeatherModel>(weatherUrl, HttpMethod.Get);
		}

		public async Task<ExtendedForecastModel> GetFiveDayWeather(Position latlng)
		{
			//string weatherUrl = Urls.CurrentWeatherUrl;
			return await WrapHttpCall<ExtendedForecastModel>("weatherUrl", HttpMethod.Get);
		}
	}
}
