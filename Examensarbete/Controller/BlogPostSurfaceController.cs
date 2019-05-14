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


            try
            {
                var contentUdi = "umb://document/" + CurrentPage.Key; ;
                var blogContent = _contentService.CreateContent(model.Headline, Udi.Parse(contentUdi), "bloggPage");
                blogContent.SetCultureName(model.Headline, "en-US");
                blogContent.SetValue("headline", model.Headline, "en-US");
                blogContent.SetValue("subject", model.Subject, "en-US");
                blogContent.SetValue("blogText", model.Message, "en-US");

                if (model.ImageFile != null)
                {
                    IMediaService mediaService = Services.MediaService;
                    IMedia media = mediaService.CreateMedia(model.ImageFile.FileName, 1104, "Image");
                    var resultAttempt = mediaService.Save(media);
                    media.SetValue("umbracoFile", model.ImageFile); // Funkar inte som det ska. Kommer in en bild utan någon data
                    mediaService.Save(media);
                    blogContent.SetValue("blogImage", media, "en-US");
                }

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
       
        public ActionResult AddComment(string Comment)
        {
            try
            {
                var blogPage = _contentService.GetById(CurrentPage.Id);
                var values = blogPage.GetValue("blogpostComment", "en-US");
                if (values == null)
                {
                    blogPage.SetValue("blogpostComment", Comment, "en-US");
                }
                else
                {
                    values = values.ToString() + Environment.NewLine + Comment;
                    blogPage.SetValue("blogpostComment", values, "en-US");
                }
                _contentService.SaveAndPublish(blogPage, "en-Us");
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