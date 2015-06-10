using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    [Table("Landen")]
    public class Land
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(ResourceType = typeof(Resource), Name = "Country")]
        public int LandId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Country")]
        public string LandNaam { get; set; }

        public virtual ICollection<Gemeente> Gemeenten { get; set; }
    }
}