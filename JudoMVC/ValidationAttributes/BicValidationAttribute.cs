using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace JudoMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BicValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            var bic = value.ToString();
            if (string.IsNullOrEmpty(bic) || bic.Length != 8 || bic.Length != 11)
                return false;
            return Regex.IsMatch(bic, "^([a-zA-Z]){4}([a-zA-Z]){2}([0-9a-zA-Z]){2}([0-9a-zA-Z]{3})?$");
        }
    }
}