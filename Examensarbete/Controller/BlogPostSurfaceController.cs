using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;
using Examensarbete.Models;
using Examensarbete.Models.ViewModels;
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
            return PartialView("CreateBlogpost", new BlogPostViewModel());
        }
        [HttpPost]
        public ActionResult Post(BlogPostViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            try
            {

                var curretPageGuid = CurrentPage.Key;
                var parentId = new Guid("3cce2545-e3ac-44ec-bf55-a52cc5965db3");
                var request = _contentService.CreateAndSave(model.Subject, 1075, "BloggPage");
                request.PublishName = model.Subject;
                
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