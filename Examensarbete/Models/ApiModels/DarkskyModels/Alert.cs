using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examensarbete.Models.ApiModels.DarkskyModels
{
    public class Alert
    {
        public string title { get; set; }
        public List<string> regions { get; set; }
        public string severity { get; set; }
        public int time { get; set; }
        public int expires { get; set; }
        public string description { get; set; }
        public string uri { get; set; }
    }
}