using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace WeatherApp.Helpers
{

	public class Notifiable : INotifyPropertyChanged
	{
		public event PropertyChangingEventHandler PropertyChanging;
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}
