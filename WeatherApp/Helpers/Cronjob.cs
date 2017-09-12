using System;
using Xamarin.Forms;

namespace WeatherApp.Helpers
{
	public static class Cronjob
	{
		public static void QueueCronJob(Action job, int timeMin)
		{
			var delay = TimeSpan.FromMinutes(timeMin);
			Device.StartTimer(delay, () =>
			{
				job();
				return true;
			});		
		}

	}
}
