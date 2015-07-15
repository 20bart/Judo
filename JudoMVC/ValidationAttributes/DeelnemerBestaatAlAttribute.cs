using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using JudoModelsLibrary;
using JudoServiceLibrary;

namespace JudoMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DeelnemerBestaatAlAttribute : ValidationAttribute
    {
        
        public string VoorNaam { get; set; }
        public string FamilieNaam { get; set; }
        public string GeboorteJaar { get; set; }
        public string Geslacht { get; set; }
        public string ClubId { get; set; }


        public DeelnemerBestaatAlAttribute(string voornaam, string familienaam, string geboortejaar, string geslacht, string clubid)
        {
            this.VoorNaam = voornaam;
            this.FamilieNaam = familienaam;
            this.GeboorteJaar = geboortejaar;
            this.Geslacht = geslacht;
            this.ClubId = clubid;
        }

        public override bool IsValid(object value)
        {
            var objectType = value.GetType();
            var neededProperties =
                objectType.GetProperties()
                .Where(propertyInfo => propertyInfo.Name == VoorNaam || propertyInfo.Name == FamilieNaam || propertyInfo.Name == GeboorteJaar || propertyInfo.Name == Geslacht || propertyInfo.Name == ClubId)
                .ToArray();


            if (neededProperties.Count() != 5)
            {
                throw new ApplicationException("DeelnemerBestaatAl error on " + objectType.Name);
            }

            var isValid = false;

            var voornaam = Convert.ToString(neededProperties.FirstOrDefault(name => name.Name == "Voornaam").GetValue(value, null));
            var familienaam = Convert.ToString(neededProperties.FirstOrDefault(name => name.Name == "Familienaam").GetValue(value, null));
            var geslacht = (Geslacht)neededProperties.FirstOrDefault(name => name.Name == "Geslacht").GetValue(value, null);
            int geboortejaar;
            if (int.TryParse(neededProperties.FirstOrDefault(name => name.Name == "GeboorteJaar").GetValue(value, null).ToString(), out geboortejaar))
            {
                int clubid;
                if (int.TryParse(neededProperties.FirstOrDefault(name => name.Name == "ClubId").GetValue(value, null).ToString(), out clubid))
                {
                    var deelnemerService = new DeelnemerService();
                    if (!deelnemerService.DeelnemerExists(voornaam, familienaam, geboortejaar, geslacht, clubid))
                        isValid = true;
                }
            }
            return isValid;
        }
        
    }
}