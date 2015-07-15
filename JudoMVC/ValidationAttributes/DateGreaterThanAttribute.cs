using System;
using System.ComponentModel.DataAnnotations;

namespace JudoMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public DateGreaterThanAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherPropertyName);

                if(otherPropertyInfo.PropertyType == new DateTime().GetType())
                {
                    DateTime toValidate = (DateTime)value;
                    DateTime referenceProperty =(DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    if (toValidate.CompareTo(referenceProperty) < 1)
                    {
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occured while validating the property. OtherProperty is not of type DateTime");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return validationResult;
        }
    }
}