using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        public WeatherForecastController()
        {
           
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=45.657974&lon=25.601198&exclude=hourly,minutely&appid=1637fc62cd976a8699f16ac5f7d9b92f");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return ConvertResponseToWeatherForecast(response.Content);
        }


        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content,int days = 5)
        {
            var json = JObject.Parse(content);
            var rng = new Random();
            
            return Enumerable.Range(1, days).Select(index => {
            JToken jsonDailyForecast = json["daily"][index-1];
            var unixDateTime = json["daily"][index-1].Value<long>("dt");

                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = jsonDailyForecast["temp"].Value<int>("day") - 272,
                    Summary = jsonDailyForecast["weather"][0].Value<string>("main")
                };
            })
            .ToArray();
        

        }
    }
    public class WeatherForecastControllerForCoord : ControllerBase
    {


        public WeatherForecastControllerForCoord()
        {

        }

        [HttpGet]
        public WeatherForecastLatLong Get()
        {
        
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=Brasov&appid=1637fc62cd976a8699f16ac5f7d9b92f");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return ConvertResponseToCoords(response.Content);
        }


        public WeatherForecastLatLong ConvertResponseToCoords(string content)
        {
            var json2 = JObject.Parse(content);

                return new WeatherForecastLatLong
                {
                    Lat = json2.Value<float>("lat"),
                    Longit = json2.Value<float>("lon"),
                };


        }
    }
}
