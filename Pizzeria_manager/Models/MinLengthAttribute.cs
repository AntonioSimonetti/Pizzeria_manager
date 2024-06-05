using System.ComponentModel.DataAnnotations;

namespace Pizzeria_manager.Models
{
    public class MinLengthAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }
        public MinLengthAttribute() { }

        public MinLengthAttribute(int minLength) 
        { 
            this.MinLength = minLength;
        }
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if(fieldValue == null || fieldValue.Length < MinLength)
            {

                return new ValidationResult($"il campo deve contenere almeno {MinLength} lettere");
            }

            return ValidationResult.Success;
        }
    }
}
