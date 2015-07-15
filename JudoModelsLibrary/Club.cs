using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    public class Club
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(ResourceType = typeof(Resource), Name = "ClubNumber")]
        public string ClubNummer { get; set; }

        [Required]
        [StringLength(100)]
        [Display(ResourceType = typeof(Resource), Name = "ClubName")]
        public string Naam { get; set; }

        [Required]
        [StringLength(100)]
        [Display(ResourceType = typeof(Resource), Name = "Street")]
        public string Adres { get; set; }

        [Required]
        [StringLength(10)]
        [Display(ResourceType = typeof(Resource), Name = "Number")]
        public string Huisnummer { get; set; }

        public int PostcodeId { get; set; }

        public int VerantwoordelijkeId { get; set; }
        
        public int? RekeningNummerId { get; set; }

        public virtual RekeningNummer RekeningNummer { get; set; }
        
        public virtual Gemeente Gemeente { get; set; }

        public virtual Verantwoordelijke Verantwoordelijke { get; set; }

        public virtual ICollection<Deelnemer> Deelnemers { get; set; }

        public virtual ICollection<InschrijvingsFormulier> InschrijvingsFormulieren { get; set; }
    }
}