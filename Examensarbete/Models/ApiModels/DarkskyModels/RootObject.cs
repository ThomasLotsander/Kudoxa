using System.Collections.Generic;

namespace Examensarbete.Models.ApiModels.DarkskyModels
{
    public class RootObject
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public Currently currently { get; set; }
        public Hourly hourly { get; set; }
        public Daily daily { get; set; }
        public List<Alert> alerts { get; set; }
        public Flags flags { get; set; }
        public int offset { get; set; }
    }
}