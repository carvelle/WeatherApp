using System.Net;

namespace WeatherApp.Models
{
	public interface IBaseResponseModel
	{
		HttpStatusCode StatusCode { get; set; }
	}
}