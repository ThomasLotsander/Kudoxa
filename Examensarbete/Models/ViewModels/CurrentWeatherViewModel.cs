using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examensarbete.Models.ViewModels
{
    public class CurrentWeatherViewModel
    {
        public double ApparentTemperature { get; set; }

        public string WeatherDescription { get; set; }

        public double Temperature { get; set; }

        public string WindBearing { get; set; }

        public double WindGust { get; set; }

        public double WindSpeed { get; set; }

        public string Icon { get; set; }

        public DateTime TimeOfDay { get; set; }
        

    }
}