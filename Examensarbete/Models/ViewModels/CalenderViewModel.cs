﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Umbraco.Core.PropertyEditors;

namespace Examensarbete.Models.ViewModels
{
    public class CalenderViewModel
    {
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Ankomstdatum")]
        public DateTime ArrivalDate { get; set; }

        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Hemresa")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Antal resenärer")]
        public int NumberOfPeople { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

    }
}