using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using JudoModelsLibrary;
using JudoServiceLibrary;

namespace JudoMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DeelnemerBestaatAlAttribute : ValidationAttribute
    {
        
        public String VoorNaam { get; set; }
        public String FamilieNaam { get; set; }
        public String GeboorteJaar { get; set; }
        public String Geslacht { get; set; }
        public String ClubId { get; set; }


        public DeelnemerBestaatAlAttribute(String voornaam, String familienaam, String geboortejaar, String geslacht, String clubid)
        {
            this.VoorNaam = voornaam;
            this.FamilieNaam = familienaam;
            this.GeboorteJaar = geboortejaar;
            this.Geslacht = geslacht;
            this.ClubId = clubid;
        }

        public override Boolean IsValid(Object value)
        {
            Type objectType = value.GetType();
            PropertyInfo[] neededProperties =
                objectType.GetProperties()
                .Where(propertyInfo => propertyInfo.Name == VoorNaam || propertyInfo.Name == FamilieNaam || propertyInfo.Name == GeboorteJaar || propertyInfo.Name == Geslacht || propertyInfo.Name == ClubId)
                .ToArray();


            if (neededProperties.Count() != 5)
            {
                throw new ApplicationException("DeelnemerBestaatAl error on " + objectType.Name);
            }

            Boolean isValid = false;

            var voornaam = Convert.ToString(neededProperties.FirstOrDefault(name => name.Name == "Voornaam").GetValue(value, null));
            var familienaam = Convert.ToString(neededProperties.FirstOrDefault(name => name.Name == "Familienaam").GetValue(value, null));
            var geslacht = (Geslacht)neededProperties.FirstOrDefault(name => name.Name == "Geslacht").GetValue(value, null);
            int geboortejaar;
            int clubid;
            if (int.TryParse(neededProperties.FirstOrDefault(name => name.Name == "GeboorteJaar").GetValue(value, null).ToString(), out geboortejaar))
            {
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