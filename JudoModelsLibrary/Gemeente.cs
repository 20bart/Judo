using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    [Table("Gemeenten")]
    public class Gemeente
    {
        [Key]
        public int PostcodeId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(ResourceType = typeof(Resource), Name = "PostalCode")]
        public string Postcode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof(Resource), Name = "City")]
        public string Plaats { get; set; }

        [Required]
        public int LandId { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }

        public virtual Land Land { get; set; }
    }
}