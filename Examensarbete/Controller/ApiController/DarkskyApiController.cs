using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Examensarbete.Models.ApiModels.DarkskyModels;
using Examensarbete.Service;
using Umbraco.Web.WebApi;

namespace Examensarbete.Controller.ApiController
{
    public class DarkskyApiController : UmbracoApiController
    {
        // GET: DarkskyApi
        public async Task<RootObject> Get()
        {
            WeatherData data = new WeatherData();
            var result = await data.GetTodaysWeather();

            return result;
        }
    }
}