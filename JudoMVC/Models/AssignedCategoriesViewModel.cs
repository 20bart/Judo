using System;
using System.ComponentModel.DataAnnotations;
using JudoMVC.ValidationAttributes;

namespace JudoMVC.Models
{
    public class AssignedCategoriesViewModel
    {
        public int LeeftijdCategorieId { get; set; }
        public string LeeftijdCategorieNaam { get; set; }
        public bool Assigned { get; set; }

        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public DateTime StartWeging { get; set; }

        [DateGreaterThan("StartWeging", ErrorMessageResourceName = "EndTimeMustBeLaterThanStartTime", ErrorMessageResourceType = typeof(MyResources.Models.Resource))]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public DateTime EindeWeging { get; set; }

        [DateGreaterThan("EindeWeging", ErrorMessageResourceName = "EndTimeMustBeLaterThanStartTime", ErrorMessageResourceType = typeof(MyResources.Models.Resource))]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public DateTime StartWedstrijden { get; set; }
    }
}