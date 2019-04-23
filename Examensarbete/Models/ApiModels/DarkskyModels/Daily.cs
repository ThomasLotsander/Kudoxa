using System.Collections.Generic;

namespace Examensarbete.Models.ApiModels.DarkskyModels
{
    public class Daily
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<Datum2> data { get; set; }
    }
}