using System;
using System.Collections.Generic;
using System.IO;
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


            // Save Image
            IMediaService mediaService = Services.MediaService;

            IMedia media1 = mediaService.CreateMedia("Media File Base", 1104, "Image");
            var media = mediaService.Save(media1);
            media1.SetValue("umbracoFile", model.ImageFile);

            


            mediaService.Save(media1);

            using (var ms = new MemoryStream())
            {
                ms.CopyTo(model.ImageFile.InputStream);

                var buffer = ms.GetBuffer();
               media1.SetValue("umbracoFile", buffer);
            }

            try
            {
                var curretPageGuid = CurrentPage.Key;
                var baseUdi = "umb://document/";
                var contentUdi = baseUdi + curretPageGuid;
                var blogContent = _contentService.CreateContent(model.Subject, Udi.Parse(contentUdi), "bloggPage");
                blogContent.SetCultureName(model.Headline, "en-US");
                var result = _contentService.SaveAndPublish(blogContent, "en-US");

                if (!result.Success)
                {
                    TempData["PublishFaild"] = "Kunde inte skapa blogginlägget";
                }

                return RedirectToCurrentUmbracoPage();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["PublishFaild"] = e.Message;
                return RedirectToCurrentUmbracoPage();
            }


        }
    }
}