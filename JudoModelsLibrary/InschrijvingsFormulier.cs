using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    public class InschrijvingsFormulier
    {
        [Key]
        public int InschrijvingsId { get; set; }

        public int TornooiId { get; set; }

        public int ClubId { get; set; }

        [Column(TypeName = "Date")]
        [Display(ResourceType = typeof(Resource), Name = "RegistrationDate")]
        public DateTime DatumInschrijving { get; set; }

        public virtual Club Club { get; set; }

        public virtual ICollection<InschrDeelnemer> InschrDeelnemers { get; set; }

        public virtual Tornooi Tornooi { get; set; }
    }
}