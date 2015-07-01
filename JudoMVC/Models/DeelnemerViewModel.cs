using System.ComponentModel.DataAnnotations;
using JudoModelsLibrary;
using JudoMVC.ValidationAttributes;
using MyResources.Deelnemer;

namespace JudoMVC.Models
{
    [DeelnemerBestaatAl("Voornaam", "Familienaam", "GeboorteJaar", "Geslacht", "ClubId", ErrorMessageResourceName = "DeelnemerExistsError", ErrorMessageResourceType = typeof(Resource))]
    public class DeelnemerViewModel
    {
        public int DeelnemerId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="LastName", ResourceType = typeof(Resource))]
        public string Familienaam { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        public string Voornaam { get; set; }

        [Required]
        [Display(Name="Gender", ResourceType = typeof(Resource))]
        public Geslacht Geslacht { get; set; }

        [Required]
        [Range(1900, 2500, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "BirthYearRangeError")]
        [DisplayFormat(DataFormatString="{0000}", ApplyFormatInEditMode=true)]
        [Display(Name="BirthYear", ResourceType = typeof(Resource))]
        public int? GeboorteJaar { get; set; }

        [Required]
        public int ClubId { get; set; }
    }
}