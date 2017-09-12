using Xamarin.Forms;

namespace WeatherApp.Views
{
	public partial class DashboardView : ContentPage
	{
		DashboardViewModel viewModel;
		public DashboardView()
		{
			InitializeComponent();
			BindingContext = viewModel = new DashboardViewModel();
		}
	}
}
