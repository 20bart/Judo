using System.ComponentModel.DataAnnotations;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    public class RekeningNummer
    {
        [Key]
        public int RekeningNummerId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "IBAN")]
        public string IBAN { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "BIC")]
        public string BIC { get; set; }
    }
}
