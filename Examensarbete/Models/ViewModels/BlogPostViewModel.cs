using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examensarbete.Models.ViewModels
{
    public class BlogPostViewModel
    {
       
        public int Id { get; set; }

        [Display(Name = "Ämne:")]
        [Required(ErrorMessage = "Vänligne skriv ett ämne")]
        public string Subject { get; set; }

        [Display(Name = "Rubrik:")]
        [Required(ErrorMessage = "Vänligne skriv en rubrik")]
        public string Headline { get; set; }

        [Display(Name = "Meddelande:")]
        [Required(ErrorMessage = "Vänligne skriv ett meddelande")]
        public string Message { get; set; }

        [Display(Name = "Ladda upp en bild:")]
        public HttpPostedFileBase ImageFile { get; set; }
        
        


    }
}