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

        [Required]
        [Display(Name = "Ämne:")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Rubrik:")]
        public string Headline { get; set; }

        [Required]
        [Display(Name = "Meddelande:")]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}