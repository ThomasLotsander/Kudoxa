using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using Examensarbete.Models.ApiModels.DarkskyModels;
using Examensarbete.Models.ViewModels;

namespace Examensarbete.Service
{
    public class WeatherData
    {
        public async Task<RootObject> GetTodaysWeather()
        {
            // TODO: Get weather with DarkSkyApi

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.darksky.net/");
                    client.DefaultRequestHeaders.Clear();
                    var response = await client.GetAsync(
                        "forecast/d21e59d1b4a161b34fd28213b1e3eabe/59.659,19.124?lang=sv&units=si");
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));

                    Stream stream = await response.Content.ReadAsStreamAsync();
                    RootObject result = (RootObject)serializer.ReadObject(stream);
                    return result;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public CurrentWeatherViewModel GetCurrentWeatherViewModel(RootObject model)
        {
            var viewModel = new CurrentWeatherViewModel();
            viewModel.WindBearing = GetWindBearing((int)model.currently.windBearing);

            viewModel.ApparentTemperature = model.currently.apparentTemperature;
            viewModel.Temperature = model.currently.temperature;
            viewModel.WeatherDescription = model.currently.summary;
            viewModel.WindGust = model.currently.windGust;
            viewModel.WindSpeed = model.currently.windSpeed;


            return viewModel;
        }

        private string GetWindBearing(int windBearing)
        {
            string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            return caridnals[(int)Math.Round(((double)windBearing * 10 % 3600) / 225)];
        }
    }
}