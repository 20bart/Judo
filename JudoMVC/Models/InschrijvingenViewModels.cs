using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JudoModelsLibrary;
using MyResources.Deelnemer;

namespace JudoMVC.Models
{
    public class DeelnemerCheckedViewModel
    {
        public int DeelnemerId { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        public string Familienaam { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        public string Voornaam { get; set; }

        [Required]
        [Display(Name = "Gender", ResourceType = typeof(Resource))]
        public Geslacht Geslacht { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0000}", ApplyFormatInEditMode = true)]
        [Display(Name = "BirthYear", ResourceType = typeof(Resource))]
        public int? GeboorteJaar { get; set; }

        [Required]
        public int ClubId { get; set; }

        public bool Assigned { get; set; }
    }
}