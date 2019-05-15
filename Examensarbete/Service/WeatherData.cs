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
using NPoco.Expressions;

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
                    CurrentHour = GetCurrentTime(model.offset, current.time).Hour

                };

                return viewModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public DailyWeatherforecastViewModel GetDailyWeatherforecastViewModel(Datum2 model)
        {
            var viewModel = new DailyWeatherforecastViewModel()
            {
                Day = GetCurrentTime(2, (int)model.time).ToString("dddd, dd MMMM"),
                Icon = GetIconSerachString(model.icon),
                Summary = model.summary,
                Sunrise = GetCurrentTime(2, (int)model.sunriseTime).ToString("HH:mm"),
                SunSet = GetCurrentTime(2, (int)model.sunsetTime).ToString("HH:mm"),
                TempMax = Math.Round(model.temperatureHigh),
                TempMin = Math.Round(model.temperatureLow),
                WindBearing = GetWindBearing((int)model.windBearing),
                WindGust = Math.Round(model.windGust),
                WindSpeed = Math.Round(model.windSpeed)
            };
            return viewModel;
        }

        public HourlyWeatherForecastViewModel GetHourlyWeatherViewModel(Datum model)
        {
            var viewModel = new HourlyWeatherForecastViewModel()
            {
                Hour = GetCurrentTime(2, (int)model.time).Hour.ToString(),
                Icon = GetIconSerachString(model.icon),
                Temp = Math.Round(model.temperature),
                WindBearing = GetWindBearing((int)model.windBearing),
                WindGust = Math.Round(model.windGust),
                WindSpeed = Math.Round(model.windSpeed)
            };

            return viewModel;
        }

        private DateTime GetCurrentTime(double hours, int time)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            var current = dt.AddHours(Math.Floor(hours)).AddSeconds(time);
            return current;
        }

        private string GetWindBearing(int heading)
        {
            var directions = new string[] {
                "Nordlig", "Nordostlig ", "Östlig", "Sydostligos", "Sydlig", "Sydvästlig", "Västlig ", "Nordvästlig", "Nordlig"
            };

            var index = (heading + 23) / 45;
            return directions[index] + " vind";
        }

        private string GetIconSerachString(string icon)
        {
            return "/Static/Images/DarkskyApi/" + icon + ".svg";
        }

    }
}