using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
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
            // TODO: Fix try catch / Handle error
            try
            {
                var current = model.currently;
                var viewModel = new CurrentWeatherViewModel()
                {
                    WindBearing = GetWindBearing((int)current.windBearing),
                    Temperature = (int)Math.Round(current.temperature),
                    WindGust = (int)Math.Round(current.windGust),
                    WindSpeed = (int)Math.Round(current.windSpeed),
                    Icon = GetIconSerachString(current.icon),
                    CurrentHour = GetCurrentTime(model.offset, current.time)

            };

                return viewModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        public Datum2 GetDailyWeatherforecastViewModel(Datum2 model)
        {
            return model;
        }

        private int GetCurrentTime(double hours, int time)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            var current = dt.AddHours(Math.Floor(hours)).AddSeconds(time);
            return current.Hour;
        }

        private string GetWindBearing(int windBearing)
        {
            string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            return caridnals[(int)Math.Round(((double)windBearing * 10 % 3600) / 225)];
        }

        private string GetIconSerachString(string icon)
        {
            return "/Static/Images/DarkskyApi/" + icon + ".svg";
        }

    }
}