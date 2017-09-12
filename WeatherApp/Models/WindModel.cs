using Newtonsoft.Json;

namespace WeatherApp.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class WindModel
	{
		[JsonProperty("speed")]
		public double Speed { get; set; }

		[JsonProperty("deg")]
		public double Bearing { get; set; }

	}
}
