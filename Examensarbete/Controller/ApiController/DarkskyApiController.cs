using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
            WeatherData data = new WeatherData();
            var result = await data.GetTodaysWeather();

            var model = data.GetCurrentWeatherViewModel(result);

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {

                    // Serializer the User object to the stream.  
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CurrentWeatherViewModel));
                    ser.WriteObject(ms, model);
                    byte[] json = ms.ToArray();
                    var jsonString = Encoding.UTF8.GetString(json, 0, json.Length);
                    return jsonString;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }
    }
}