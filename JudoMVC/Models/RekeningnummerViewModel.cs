using System.ComponentModel.DataAnnotations;
using JudoMVC.ValidationAttributes;
using MyResources.Models;

namespace JudoMVC.Models
{
    public class RekeningnummerViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "IBAN")]
        [Rekeningnummer(ErrorMessageResourceName = "IbanNotValid", ErrorMessageResourceType = typeof(Resource))]
        public string IBAN { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "BIC")]
        [BicValidation(ErrorMessageResourceName = "BicNotValid", ErrorMessageResourceType = typeof(Resource))]
        public string BIC { get; set; }
    }
}