using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Examensarbete.Models.ViewModels;
using Examensarbete.Service;
using Umbraco.Web.Mvc;

namespace Examensarbete.Controller
{
    public class WeatherSurfaceController : SurfaceController
    {
        // GET: WeatherSurface
        public async Task<ActionResult> Index()
        {
            try
            {
                return PartialView("_Weather");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}