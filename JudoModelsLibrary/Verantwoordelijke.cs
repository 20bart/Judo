using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    [Table("Verantwoordelijken")]
    public class Verantwoordelijke
    {
        [Key]
        public int VerantwoordelijkeId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof(Resource), Name = "LastName")]
        public string Familienaam { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof(Resource), Name = "FirstName")]
        public string Voornaam { get; set; }

        [Required]
        [StringLength(15)]
        [Display(ResourceType = typeof(Resource), Name = "Phone")]
        public string Telefoonnummer { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof(Resource), Name = "Email")]
        public string Email { get; set; }

        public virtual ICollection<Club> Club { get; set; }
    }
}