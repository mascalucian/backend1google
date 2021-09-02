﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


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

            var rng = new Random();
            //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //    {
            //        Date = DateTime.Now.AddDays(index),
            //        TemperatureC = rng.Next(-20, 55),
            //        Summary = Summaries[rng.Next(Summaries.Length)]
            //    })
            //    .ToArray();
            //    //https://api.openweathermap.org/data/2.5/onecall?lat=45.657974&lon=25.601198&exclude=hourly,minutely&appid=1637fc62cd976a8699f16ac5f7d9b92f
            //"{\"lat\":45.658,\"lon\":25.6012,\"timezone\":\"Europe/Bucharest\",\"timezone_offset\":10800,\"current\":{\"dt\":1630565287,\"sunrise\":1630554008,\"sunset\":1630601692,\"temp\":284.96,\"feels_like\":284.29,\"pressure\":1017,\"humidity\":80,\"dew_point\":281.63,\"uvi\":0.65,\"clouds\":100,\"visibility\":10000,\"wind_speed\":4.82,\"wind_deg\":310,\"wind_gust\":10.31,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}]},\"daily\":[{\"dt\":1630576800,\"sunrise\":1630554008,\"sunset\":1630601692,\"moonrise\":1630534320,\"moonset\":1630593720,\"moon_phase\":0.84,\"temp\":{\"day\":286.86,\"min\":283.22,\"max\":289.04,\"night\":283.22,\"eve\":287.37,\"morn\":284.73},\"feels_like\":{\"day\":286.19,\"night\":282.5,\"eve\":286.62,\"morn\":284.29},\"pressure\":1019,\"humidity\":73,\"dew_point\":282.11,\"wind_speed\":7.13,\"wind_deg\":307,\"wind_gust\":11.23,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":99,\"pop\":0.38,\"rain\":0.62,\"uvi\":3.88},{\"dt\":1630663200,\"sunrise\":1630640481,\"sunset\":1630687980,\"moonrise\":1630624080,\"moonset\":1630682700,\"moon_phase\":0.88,\"temp\":{\"day\":291.43,\"min\":280.18,\"max\":292.82,\"night\":283.9,\"eve\":289.64,\"morn\":280.18},\"feels_like\":{\"day\":290.57,\"night\":283.15,\"eve\":289.02,\"morn\":280.18},\"pressure\":1021,\"humidity\":48,\"dew_point\":279.14,\"wind_speed\":2.97,\"wind_deg\":307,\"wind_gust\":3.89,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":3,\"pop\":0,\"uvi\":5.87},{\"dt\":1630749600,\"sunrise\":1630726954,\"sunset\":1630774267,\"moonrise\":1630714320,\"moonset\":1630771320,\"moon_phase\":0.91,\"temp\":{\"day\":293.29,\"min\":282.05,\"max\":294.62,\"night\":285.37,\"eve\":291.2,\"morn\":282.05},\"feels_like\":{\"day\":292.59,\"night\":284.63,\"eve\":290.63,\"morn\":282.05},\"pressure\":1017,\"humidity\":47,\"dew_point\":280.69,\"wind_speed\":2.23,\"wind_deg\":324,\"wind_gust\":2.96,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":0,\"pop\":0,\"uvi\":5.67},{\"dt\":1630836000,\"sunrise\":1630813428,\"sunset\":1630860553,\"moonrise\":1630804860,\"moonset\":1630859580,\"moon_phase\":0.94,\"temp\":{\"day\":290.23,\"min\":284.2,\"max\":292,\"night\":285.14,\"eve\":290.4,\"morn\":284.62},\"feels_like\":{\"day\":289.64,\"night\":284.54,\"eve\":289.85,\"morn\":283.96},\"pressure\":1020,\"humidity\":63,\"dew_point\":282.07,\"wind_speed\":2.17,\"wind_deg\":70,\"wind_gust\":4.39,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":88,\"pop\":0.34,\"rain\":1.32,\"uvi\":3.74},{\"dt\":1630922400,\"sunrise\":1630899901,\"sunset\":1630946839,\"moonrise\":1630895640,\"moonset\":1630947540,\"moon_phase\":0.98,\"temp\":{\"day\":286.24,\"min\":283.62,\"max\":289.46,\"night\":285.38,\"eve\":289.46,\"morn\":283.62},\"feels_like\":{\"day\":285.17,\"night\":284.36,\"eve\":288.58,\"morn\":282.63},\"pressure\":1026,\"humidity\":60,\"dew_point\":277.45,\"wind_speed\":2.38,\"wind_deg\":110,\"wind_gust\":5.47,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":100,\"pop\":0.02,\"uvi\":1.71},{\"dt\":1631008800,\"sunrise\":1630986374,\"sunset\":1631033124,\"moonrise\":1630986540,\"moonset\":1631035320,\"moon_phase\":0,\"temp\":{\"day\":291.63,\"min\":283.83,\"max\":294.05,\"night\":286.15,\"eve\":292.74,\"morn\":283.83},\"feels_like\":{\"day\":290.73,\"night\":285.26,\"eve\":291.96,\"morn\":282.55},\"pressure\":1025,\"humidity\":46,\"dew_point\":278.74,\"wind_speed\":2.76,\"wind_deg\":176,\"wind_gust\":3.43,\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":55,\"pop\":0,\"uvi\":2},{\"dt\":1631095200,\"sunrise\":1631072847,\"sunset\":1631119409,\"moonrise\":1631077440,\"moonset\":1631123040,\"moon_phase\":0.05,\"temp\":{\"day\":293.33,\"min\":281.67,\"max\":295.36,\"night\":287.51,\"eve\":293.4,\"morn\":281.67},\"feels_like\":{\"day\":292.45,\"night\":286.49,\"eve\":292.58,\"morn\":281.67},\"pressure\":1019,\"humidity\":40,\"dew_point\":278.32,\"wind_speed\":3.11,\"wind_deg\":185,\"wind_gust\":4.26,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":19,\"pop\":0,\"uvi\":2},{\"dt\":1631181600,\"sunrise\":1631159320,\"sunset\":1631205694,\"moonrise\":1631168400,\"moonset\":1631210820,\"moon_phase\":0.08,\"temp\":{\"day\":294.74,\"min\":284.62,\"max\":296.04,\"night\":287.8,\"eve\":291.8,\"morn\":285.34},\"feels_like\":{\"day\":294.05,\"night\":287.15,\"eve\":291.21,\"morn\":284.55},\"pressure\":1016,\"humidity\":42,\"dew_point\":280.38,\"wind_speed\":2.14,\"wind_deg\":161,\"wind_gust\":3.02,\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":28,\"pop\":0,\"uvi\":2}]}"
        }


        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
    }
    }
}
