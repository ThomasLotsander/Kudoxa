using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Web;
using Examensarbete.Models.ApiModels.DarkskyModels;

namespace Examensarbete.Models.ViewModels
{
    public class WeatherInfoViewModel
    {
        public CurrentWeatherViewModel CurrentWeather { get; set; }

        public List<Datum2> DailyWeatherforecasts{ get; set; } = new List<Datum2>();

    }
}