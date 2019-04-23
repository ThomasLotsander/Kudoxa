using System.Collections.Generic;
using Newtonsoft.Json;

namespace Examensarbete.Models.ApiModels.DarkskyModels
{
    public class Flags
    {
        public List<string> sources { get; set; }

        [JsonProperty(PropertyName = "meteoalarm-license")]
        public string meteoalarmLicense { get; set; }

        [JsonProperty(PropertyName = "nearest-station")]
        public double nearestStation { get; set; }
        public string units { get; set; }
    }
}