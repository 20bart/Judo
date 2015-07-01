using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudoMVC.Models
{
    public class AssignedCategoriesViewModel
    {
        public int LeeftijdCategorieId { get; set; }
        public string LeeftijdCategorieNaam { get; set; }
        public bool Assigned { get; set; }
    }
}