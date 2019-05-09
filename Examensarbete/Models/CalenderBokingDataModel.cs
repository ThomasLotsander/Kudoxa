using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examensarbete.Models
{
    public class CalenderBokingDataModel
    {
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Name { get; set; }
        public int NumberOfPeople { get; set; }
    }
}