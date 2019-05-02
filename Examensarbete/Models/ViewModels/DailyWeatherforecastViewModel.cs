using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Examensarbete.Models.ApiModels.DarkskyModels;

namespace Examensarbete.Models.ViewModels
{
    public class DailyWeatherforecastViewModel
    {

        public string Icon { get; set; }

        public string Summary { get; set; }

        public string Sunrise { get; set; }
        public string SunSet { get; set; }

        public double TempMax { get; set; }

        public double TempMin { get; set; }

        public string Day { get; set; }

        public string WindBearing { get; set; }

        public double WindGust { get; set; }

        public double WindSpeed { get; set; }
    }
}