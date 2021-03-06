﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        CalenderBusiness calenderBusiness = new CalenderBusiness();
        public ActionResult Index()
        {
            var model = new CalenderViewModel()
            {
                ArrivalDate = DateTime.Today.ToString("dd/MM/yyyy"),
                ReturnDate = DateTime.Today.AddDays(1).ToString("dd/MM/yyyy"),
                CalenderBokings = data.GetUpToDateCalenderBokings()
            };
            return PartialView("CalenderBooking", model);
        }

        [HttpPost]
        public ActionResult BookDate(CalenderViewModel model)
        {
    
            // Workarount to make ModelState work.
            ModelState.Remove("CalenderBokings");
            if (ModelState.IsValid)
            {
                DateTime arrivalDate = DateTime.ParseExact(model.ArrivalDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime returnDate = DateTime.ParseExact(model.ReturnDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (!calenderBusiness.ReturnDateIsLaterThenArrivalDate(arrivalDate, returnDate))
                {
                    TempData["BokingMessage"] = "Du kan inte boka en hemfärd som är tidigare än utfärden.";
                    
                }
                else
                {
                    CalenderBoking dataModel = new CalenderBoking()
                    {
                        ArrivalDate = arrivalDate,
                        ReturnDate = returnDate,
                        Name = model.Name,
                        NumberOfPeople = model.NumberOfPeople
                    };
                    var saveSuccessMessage = data.SaveCalenderBoking(dataModel);
                    TempData["BokingMessage"] = saveSuccessMessage;
                }
                var content = Services.ContentService.GetById(CurrentPage.Id);
                Services.ContentService.SaveAndPublish(content, "en-US");
                return RedirectToCurrentUmbracoPage();

            }

            return CurrentUmbracoPage();
        }

    }
}