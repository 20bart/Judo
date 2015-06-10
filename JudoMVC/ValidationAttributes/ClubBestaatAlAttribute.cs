using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using JudoServiceLibrary;

namespace JudoMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClubBestaatAlAttribute : ValidationAttribute
    {
        public String FirstPropertyName { get; set; }
        public String SecondPropertyName { get; set; }

        public ClubBestaatAlAttribute(String firstPropertyName, String secondPropertyName)
        {
            FirstPropertyName = firstPropertyName;
            SecondPropertyName = secondPropertyName;
        }

        public override Boolean IsValid(Object value)
        {
            Type objectType = value.GetType();
            PropertyInfo[] neededProperties =
              objectType.GetProperties()
              .Where(propertyInfo => propertyInfo.Name == FirstPropertyName || propertyInfo.Name == SecondPropertyName)
              .ToArray();

            if (neededProperties.Count() != 2)
            {
                throw new ApplicationException("ClubBestaatAl error on " + objectType.Name);
            }

            Boolean isValid = false;

            var clubnummer = Convert.ToString(neededProperties[0].GetValue(value, null));
            int landId;
            if (int.TryParse(neededProperties[1].GetValue(value, null).ToString(),out landId))
            {
                var clubService = new ClubService();
                if (!clubService.ClubExists(clubnummer, landId))
                    isValid = true;
            }
            return isValid;
        }
    }
}
