using System.ComponentModel.DataAnnotations;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    public class InschrDeelnemer
    {
        [Key]
        public int InschrDeelnemerId { get; set; }

        public int InschrijvingsId { get; set; }

        public int DeelnemersId { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "PaymentConfirmed")]
        public bool Betaald { get; set; }

        public virtual Deelnemer Deelnemer { get; set; }

        public virtual InschrijvingsFormulier InschrijvingsFormulier { get; set; }
    }
}