using System;
namespace WeatherApp
{
	public static class DateTimeUtil
	{

		public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
		{
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}

		public static String UnixTimeStampToDateTimeString(double unixTimeStamp)
		{
			var datetime = UnixTimeStampToDateTime(unixTimeStamp);
			return datetime.ToString("dddd, MMMM dd");
		}

	}
}
