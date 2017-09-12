using Newtonsoft.Json;

namespace WeatherApp.Model
{
	[JsonObject(MemberSerialization.OptIn)]
	public class CloudsModel
	{
		[JsonProperty("all")]
		public double All { get; set; }
	}
}
