using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudoModelsLibrary
{
    public class TornooiLeeftijdCategorie
    {
        [Key, Column(Order = 0)]
        public int TornooiId { get; set; }

        [Key, Column(Order = 1)]
        public int LeeftijdCategorieId { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartWeging { get; set; }

        [DataType(DataType.Time)]
        public DateTime EindeWeging { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartWedstrijden { get; set; }

        public virtual Tornooi Tornooi { get; set; }
        public virtual LeeftijdCategorie LeeftijdCategorie { get; set; }
    }
}
