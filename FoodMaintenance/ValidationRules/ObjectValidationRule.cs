using System.Globalization;
using System.Windows.Controls;

namespace FoodMaintenance.ValidationRules
{
    public class ObjectValidationRule : ValidationRule
    {
        public bool AllowNull { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!AllowNull && value == null) { return new ValidationResult(false, $"Must not be null."); }

            return new ValidationResult(true, null);
        }
    }
}

