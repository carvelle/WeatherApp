using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Extentions;

namespace WeatherApp.Network
{
	public class HttpClientWrapper : IHttpClientDataProvider
	{
		public async Task<WebResponse> RequestAsync(string requestUri, HttpMethod method)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(requestUri));
			request.ContentType = "application/json";
			request.Method = method.Method;

			return await request.GetResponseAsync().TimeoutAfter(60000);
		}
	}
}