using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;
using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
	public interface IDataProvider
	{
		Task<CurrentWeatherModel> GetCurrentWeather(Position latlng);
		Task<ExtendedForecastModel> GetFiveDayWeather(Position latlng);
	}
}
