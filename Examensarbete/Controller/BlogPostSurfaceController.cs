using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;
using Examensarbete.Models;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace Examensarbete.Controller
{
    public class BlogPostSurfaceController : SurfaceController
    {

        public IContentService _contentService { get; set; }

        public BlogPostSurfaceController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ActionResult Index()
        {
            return PartialView("CreateBlogpost", new BlogPost());
        }
        [HttpPost]
        public ActionResult Post(BlogPost model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            try
            {

                var curretPageGuid = CurrentPage.Key.ToString();
                var baseUdi = "umb://document/";
                var contentUdi = baseUdi + curretPageGuid;
                var result = _contentService.CreateContent("My content node", Udi.Parse(contentUdi), "contentPage");
                Services.ContentService.SaveAndPublish(result);

                return RedirectToCurrentUmbracoPage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    }
}