using System;
using System.Threading.Tasks;
using WeatherApp.Helpers;
using System.Globalization;
using System.Collections.Generic;
using WeatherApp.Extensions;
using Plugin.Geolocator.Abstractions;
using WeatherApp.Models;

namespace WeatherApp
{
	public class DashboardViewModel : BaseViewModel
	{
		public double _timestamp;
		public DateTime _weatherTime;
		public string _formattedTime;
		public string _currentLocation;
		public string _iconImage;
		public string _backgroundImage = "treefrost.jpg";
		public Position _latLong;
		readonly Action ChangeBackgroundAction;
		readonly Action RefreshDataAction;
		TemperaturePressureModel _temperatures;
		PermissionsHelper _permissionHelper;

		public double Timestamp
		{
			get { return _timestamp; }
			set
			{
				_timestamp = value;
				OnPropertyChanged();
			}
		}

		public DateTime WeatherTime{

			get { return _weatherTime; }
			set
			{
				_weatherTime = value;
				OnPropertyChanged();
			}
		}

		public string FormattedTime
		{

			get { return _formattedTime; }
			set
			{
				_formattedTime = value;
				OnPropertyChanged();
			}
		}
		public string CurrentLocation
		{

			get { return _currentLocation; }
			set
			{
				_currentLocation = value;
				OnPropertyChanged();
			}
		}

		public string IconImage
		{

			get { return _iconImage; }
			set
			{
				_iconImage = value;
				OnPropertyChanged();
			}
		}

		public string BackgroundImage
		{

			get { return _backgroundImage; }
			set
			{
				_backgroundImage = value;
				OnPropertyChanged();
			}
		}
		public TemperaturePressureModel Temperatures
		{
			get { return _temperatures;}
			set
			{
				_temperatures = value;
                OnPropertyChanged();
			}

		}

		public DashboardViewModel()
		{
			ChangeBackgroundAction = new Action(() => ManageBackground());
			RefreshDataAction = new Action(async () => await LoadWeatherData());
			_permissionHelper = new PermissionsHelper();
			LoadWeatherData();
			RegisterCronjobs();
		}

		public async Task LoadWeatherData()
		{
			bool checkPermissions = await _permissionHelper.RequestLocationPermission();
			if (!checkPermissions)
			{
				return;
			}

			_latLong = await LocationHelper.GetLocation();
			var response = await DataService.GetCurrentWeather(_latLong);
			if (response != null)
			{
				string countryname = GetCountryFromCountryCode(response.System.CountryCode);
				Temperatures = response.TempPressure;
				Timestamp = response.Timestamp;
				FormattedTime = DateTimeUtil.UnixTimeStampToDateTimeString(Timestamp);
				CurrentLocation = response.CityName + ", " + countryname;
				IconImage = GetIconImage(response.Weather);
			}
				
		}

		public string GetCountryFromCountryCode(string countrCode)
		{
			RegionInfo country = new RegionInfo(countrCode);
			string countryName = country.EnglishName;
			return countryName;
		}

		private string GetIconImage(List<WeatherModel> weatherModel)
		{
			string iconName = "";
			foreach (WeatherModel model in weatherModel)
			{
				iconName = GetIconImageUtil.GetImage(model.Icon, model.Id);
			}
			return  iconName;
		}

		public void ManageBackground()
		{
			BackgroundChanger changer = new BackgroundChanger();
			string randomImage = changer.ChangeBackground();
			ChangeBackground(randomImage);
		}

		public void ChangeBackground(string background)
		{
			BackgroundImage = background;
		}

		private void RegisterCronjobs()
		{
			Cronjob.QueueCronJob(ChangeBackgroundAction, 1);
			Cronjob.QueueCronJob(RefreshDataAction, 10);
		}
	}
}

