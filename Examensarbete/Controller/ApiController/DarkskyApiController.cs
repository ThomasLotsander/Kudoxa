using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Examensarbete.Models.ApiModels.DarkskyModels;
using Examensarbete.Models.ViewModels;
using Examensarbete.Service;
using Umbraco.Core;
using Umbraco.Core.Models.Membership;
using Umbraco.Web.WebApi;

namespace Examensarbete.Controller.ApiController
{
    public class DarkskyApiController : UmbracoApiController
    {
        // GET: DarkskyApi
        public async Task<string> Get()
        {
            try
            {

                WeatherData data = new WeatherData();
                var result = await data.GetTodaysWeather();

                WeatherInfoViewModel model = new WeatherInfoViewModel
                {
                    CurrentWeather = data.GetCurrentWeatherViewModel(result)
                };
                foreach (var dailyData in result.daily.data)
                {
                    var dailyModel = data.GetDailyWeatherforecastViewModel(dailyData);
                    model.DailyWeatherforecasts.Add(dailyModel);
                }

                foreach (var hourlyData in result.hourly.data)
                {
                    // Api:et hämtar data för 24h framåt. Jag vill bara hämta för idag.
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
                    var currentDay = dt.AddSeconds(hourlyData.time).Day;
                    var today = DateTime.Now.Day;
                   
                    if (today == currentDay)
                    {
                        var hourlyModel = data.GetHourlyWeatherViewModel(hourlyData);
                        model.HourlyWeather.Add(hourlyModel);
                    }
                }

                var jsonObject = new JavaScriptSerializer().Serialize(model);
                return jsonObject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}