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
            //return
            //    "{\"ApparentTemperature\":9,\"WeatherDescription\":\"Klart\",\"Temperature\":8.23,\"WindBearing\":\"ESE\",\"WindGust\":6.64,\"WindSpeed\":4.55,\"Icon\":\"/Static/Images/DarkskyApi/clear-day.svg\"}";
            WeatherData data = new WeatherData();
            var result = await data.GetTodaysWeather();

            var model = data.GetCurrentWeatherViewModel(result);

            try
            {

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