﻿using Newtonsoft.Json;

namespace WeatherApp.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class CoordinatesModel
	{
		[JsonProperty("lat")]
		public double Latitude { get; set; }

		[JsonProperty("lon")]
		public double Longitude { get; set; }

	}
}