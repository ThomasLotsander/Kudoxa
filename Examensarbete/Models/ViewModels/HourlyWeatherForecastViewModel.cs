using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examensarbete.Models.ViewModels
{
    public class HourlyWeatherForecastViewModel
    {
        public string Hour { get; set; }

        public string Icon { get; set; }

        public double Temp { get; set; }

        public string WindBearing { get; set; }

        public double WindGust { get; set; }

        public double WindSpeed { get; set; }
    }
}