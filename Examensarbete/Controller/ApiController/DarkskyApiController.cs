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
                foreach (var date in result.daily.data)
                {
                    var dailyModel = data.GetDailyWeatherforecastViewModel(date);
                    model.DailyWeatherforecasts.Add(dailyModel);
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