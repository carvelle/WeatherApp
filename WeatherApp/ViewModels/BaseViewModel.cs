using WeatherApp.Helpers;
using WeatherApp.Interfaces;

namespace WeatherApp
{
	public class BaseViewModel : Notifiable
	{
		public IDataProvider DataService;
		
		public BaseViewModel()
		{
			DataService = new DataProvider();
		}
	}
}
