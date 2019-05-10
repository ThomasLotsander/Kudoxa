using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace Examensarbete.Business
{
    public class CalenderBusiness
    {
        public bool ReturnDateIsLaterThenArrivalDate(DateTime arrivalDate, DateTime returnDate) =>  arrivalDate < returnDate;
    }
}