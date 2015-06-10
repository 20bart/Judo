using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using JudoMVC.ValidationAttributes;
using MyResources.Account;

namespace JudoMVC.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource),Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "RememberBrowser")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }

    [ClubBestaatAl("Clubnummer", "LandId", ErrorMessageResourceType = typeof(Resource),ErrorMessageResourceName = "ClubNumberExistsInCountry")]
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resource),Name = "EmailLogin")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "StringLengthError", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "ConfirmPassword")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PassAndConfPassNoMatch")]
        public string ConfirmPassword { get; set; }

        //Zelf bij geplaatst
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
        [Display(ResourceType = typeof(Resource), Name = "Phone")]
        public string Telefoonnummer { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resource), Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "StringLengthError", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "ConfirmPassword")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PassAndConfPassNoMatch")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resource), Name = "Email")]
        public string Email { get; set; }
    }
}
