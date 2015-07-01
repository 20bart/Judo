using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    [Table("Tornooien")]
    public class Tornooi
    {
        public Tornooi()
        {
            LeeftijdCategories = new List<LeeftijdCategorie>();
        }

        [Key]
        public int TornooiId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(ResourceType = typeof(Resource), Name = "TournamentName")]
        public string TornooiNaam { get; set; }

        [Required]
        //[Column(TypeName = "Date")]
        //[DataType(DataType.DateTime)]
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

        public int PostcodeId { get; set; }

        public int ClubId { get; set; }

        public virtual Gemeente Gemeente { get; set; }

        public virtual Club Club { get; set; }

        public virtual ICollection<InschrijvingsFormulier> InschrijvingsFormulieren { get; set; }

        public virtual ICollection<LeeftijdCategorie> LeeftijdCategories { get; set; }
    }
}