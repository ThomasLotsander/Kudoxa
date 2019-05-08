using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examensarbete.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Umbraco.Web.Mvc;
using Umbraco.Web.Security;

namespace Examensarbete.Controller
{
    public class CalenderSurfaceController : SurfaceController
    {
        [HttpPost]
        public ActionResult BookDate(CalenderViewModel model)
        {

            if (ModelState.IsValid)
            {
                
            }

            var userTicket = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current).GetUmbracoAuthTicket();
            if (userTicket != null)
            {
                var currentUser = Services.UserService.GetByUsername(userTicket.Identity.GetUserName());
            }

           
            // TODO: Save date in database
            return RedirectToCurrentUmbracoPage();
        }
    }
}