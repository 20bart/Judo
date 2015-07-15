using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JudoModelsLibrary;
using MyResources.JudoModelsLibrary;

namespace JudoMVC.Models
{
    public class TornooiViewModel
    {
        public int TornooiId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(ResourceType = typeof(Resource), Name = "TournamentName")]
        public string TornooiNaam { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Date")]
        public DateTime Datum { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationDeadline")]
        public int UitersteInschrijvingVoorAantalDagen { get; set; }

        [StringLength(100)]
        [Display(ResourceType = typeof(Resource), Name = "Place")]
        public string PlaatsNaam { get; set; }

        [Required]
        [StringLength(100)]
        [Display(ResourceType = typeof(Resource), Name = "Street")]
        public string Adres { get; set; }

        [Required]
        [StringLength(10)]
        [Display(ResourceType = typeof(Resource), Name = "Number")]
        public string Huisnummer { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationFee")]
        [DataType(DataType.Currency)]
        public decimal InschrijvingsGeld { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Comments")]
        public string Opmerkingen { get; set; }

        public int PostcodeId { get; set; }

        public int ClubId { get; set; }

        public virtual Gemeente Gemeente { get; set; }

        public virtual Club Club { get; set; }

        public virtual ICollection<AssignedCategoriesViewModel> AssignedLeeftijdCategories { get; set; }
    }
}