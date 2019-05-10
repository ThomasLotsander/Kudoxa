using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examensarbete.Business;
using Examensarbete.Models.ViewModels;
using Examensarbete.Service;
using Microsoft.AspNet.Identity;
using Umbraco.Web.Mvc;
using Umbraco.Web.Security;

namespace Examensarbete.Controller
{
    public class CalenderSurfaceController : SurfaceController
    {
        CalenderData data = new CalenderData();
        CalenderBusiness business = new CalenderBusiness();
        public ActionResult Index()
        {

            var model = new CalenderViewModel()
            {
                CalenderBokings = data.GetCalenderBokings()
            };
            model.CalenderBokings.OrderBy(m => m.ArrivalDate);
            return PartialView("CalenderBooking", model);
        }

        [HttpPost]
        public ActionResult BookDate(CalenderViewModel model)
        {
            var count = ModelState.Count;
            ModelState.Remove("CalenderBokings");
            if (ModelState.IsValid)
            {
                if (!business.ReturnDateIsLaterThenArrivalDate(model.ArrivalDate, model.ReturnDate))
                {
                    TempData["ReturnDate"] = "Du kan inte boka en hemfärd som är tidigare än utfärden.";
                    return CurrentUmbracoPage();
                }
               
                CalenderBoking dataModel = new CalenderBoking()
                {
                    ArrivalDate = model.ArrivalDate,
                    ReturnDate = model.ReturnDate,
                    Name = model.Name,
                    NumberOfPeople = model.NumberOfPeople
                };
                var saveSuccessMessage = data.SaveCalenderBoking(dataModel);
                TempData["BokingSaved"] = saveSuccessMessage;
            }

            return CurrentUmbracoPage();
        }
    }
}