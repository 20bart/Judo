using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    
    public enum Geslacht
    {
        [Display(ResourceType = typeof(Resource), Name = "Geslacht_Man")]
        Man,
        [Display(ResourceType = typeof(Resource), Name = "Geslacht_Vrouw")]
        Vrouw
    }
    public class Deelnemer
    {
        [Key]
        public int DeelnemersId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof (Resource), Name = "LastName")]
        public string Familienaam { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof (Resource), Name = "FirstName")]
        public string Voornaam { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resource), Name = "Gender")]
        public Geslacht Geslacht { get; set; }

        [Required]
        [Range(1900,2500)]
        [Display(ResourceType = typeof (Resource), Name = "BirthYear")]
        public int GeboorteJaar { get; set; }

        [Display(ResourceType = typeof (Resource), Name = "Weight")]
        public float? Gewicht { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        public virtual ICollection<InschrDeelnemer> InschrDeelnemer { get; set; }
    }
}