using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Configuration;
using System.Xml.Linq;
using MyResources.JudoModelsLibrary;

namespace JudoModelsLibrary
{
    [Table("Categorie")]
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }

        [Required]
        public int LeeftijdCategorieId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Gender")]
        public Geslacht Geslacht { get; set; }

        public int? GewichtCategorieId { get; set; }

        [Required]
        public int DuurCategorieId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Individually")]
        public bool Individueel { get; set; }

        public virtual LeeftijdCategorie LeeftijdCategorie { get; set; }
        public virtual GewichtCategorie GewichtCategorie { get; set; }
        public virtual DuurCategorie DuurCategorie { get; set; }
    }

    [Table("LeeftijdCategorie")]
    public class LeeftijdCategorie
    {
        [Key]
        public int LeeftijdCategorieId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AgeCategory")]
        public string LeeftijdCategorieNaam { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Age")]
        public int LeeftijdBegin { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Age")]
        public int LeeftijdEinde { get; set; }

        public virtual ICollection<Tornooi> Tornooien { get; set; }
    }

    [Table("GewichtCategorie")]
    public class GewichtCategorie
    {
        [Key]
        public int GewichtCategorieId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Weight")]
        public int Gewicht { get; set; }

        [Required]
        [StringLength(1)]
        public string Sign { get; set; }

    }

    [Table("DuurCategorie")]
    public class DuurCategorie
    {
        [Key]
        public int DuurCategorieId { get; set; }
        
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Duration")]
        public TimeSpan Duur { get; set; }

    }
}