using System.Collections.Generic;

namespace Examensarbete.Models.ApiModels.DarkskyModels
{
    public class Hourly
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<Datum> data { get; set; }
    }
}