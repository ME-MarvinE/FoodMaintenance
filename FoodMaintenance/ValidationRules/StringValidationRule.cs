using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace FoodMaintenance.ValidationRules
{
    public class StringValidationRule : ValidationRule
    {
        public bool AllowEmpty { get; set; }
        public bool AllowWhiteSpace { get; set; }
        public int? MinCharacterCount { get; set; }
        public int? MaxCharacterCount { get; set; }
        public string? RegexPattern{ get; set; }
        public string? RegexErrorString { get; set; } = "Invalid Format.";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? ValueString = value as string;

            if (!AllowEmpty && string.IsNullOrEmpty(ValueString)) { return new ValidationResult(false, $"Must not be empty."); }
            if (!AllowWhiteSpace && string.IsNullOrWhiteSpace(ValueString)) { return new ValidationResult(false, $"Must not be whitespace."); }

            if (ValueString.Length < MinCharacterCount)
            {
                bool Plural = MinCharacterCount != 1;
                return new ValidationResult(false, $"Minimum of {MinCharacterCount} character{(Plural ? "s" : "")}.");
            }
            if (ValueString.Length > MaxCharacterCount)
            {
                bool Plural = MaxCharacterCount != 1;
                return new ValidationResult(false, $"Minimum of {MaxCharacterCount} character{(Plural ? "s" : "")}.");
            }

            if (!string.IsNullOrEmpty(RegexPattern) && !Regex.IsMatch(ValueString, RegexPattern))
            {
                return new ValidationResult(false, RegexErrorString);
            }

            return new ValidationResult(true, null);
        }
    }
}
