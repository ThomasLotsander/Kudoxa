using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Examensarbete.Models.ApiModels.DarkskyModels;

namespace Examensarbete.Models.ViewModels
{
    public class DailyWeatherforecastViewModel
    {
        public List<Datum> Type { get; set; }
    }
}