using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Umbraco.Core.PropertyEditors;

namespace Examensarbete.Models.ViewModels
{
    public class CalenderViewModel
    {
        [Required(ErrorMessage = "Vänligen ange ett datum för ankomst")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Ankomstdatum")]
        public DateTime ArrivalDate { get; set; }

        [Required(ErrorMessage = "Vänligen ange ett datum för hemresa")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Hemresa")]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "Vänligen välj antal resenärer")]
        [Display(Name = "Antal resenärer")]
        [Range(1, int.MaxValue, ErrorMessage = "Vänligen välj anatal resenärer.")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "Vänligen skriv in ditt namn")]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        public List<CalenderBoking> CalenderBokings { get; set; }

    }
}