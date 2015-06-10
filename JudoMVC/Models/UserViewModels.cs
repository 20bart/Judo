using System.ComponentModel.DataAnnotations;
using JudoMVC.ValidationAttributes;
using MyResources.User;

namespace JudoMVC.Models
{
    [ClubBestaatAl("Clubnummer", "LandId", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ClubNumberExistsInCountry")]
    public class UserViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ClubNumber")]
        public string Clubnummer { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ClubName")]
        public string Clubnaam { get; set; }
        
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Street")]
        public string Straat { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Number")]
        public string Huisnummer { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "PostalCode")]
        public string Postcode { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "City")]
        public string Gemeente { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Country")]
        public int LandId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Country")]
        public string LandNaam { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "FirstName")]
        public string Voornaam { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "LastName")]
        public string Familienaam { get; set; }

        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resource), Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Phone")]
        public string Telefoonnummer { get; set; }
    }

    
    public class UserClubViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ClubNumber")]
        public string Clubnummer { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ClubName")]
        public string Clubnaam { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Street")]
        public string Straat { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Number")]
        public string Huisnummer { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "PostalCode")]
        public string Postcode { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "City")]
        public string Gemeente { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Country")]
        public int LandId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Country")]
        public string LandNaam { get; set; }
    }

}