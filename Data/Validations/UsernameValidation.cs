using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace D20.Data.Forms.Validations
{
    class Username : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!value.ToString().ToLower().Contains("admin") || 
                !value.ToString().ToLower().Contains("moderator") ||
                !value.ToString().ToLower().Contains("staff"))
            {
                return null;
            }

            return new ValidationResult("We prefer our users not to pretend they are staff. Please choose a different username.");
        }
    }

    class FullName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex rx = new(@"^([A-Z]\w+(\-\w+)*?)( [A-Z](\w+)?(-\w+)*?)?( [A-Z](\w+)?(\-\w+)*?)( ?(Jr.?|Sr.?)?) ?((M{0,4})?(CM|CD|D?C{0,3})?(XC|XL|L?X{0,3})?(IX|IV|V?I{0,3}))?( MD)?$", RegexOptions.Compiled);
            MatchCollection matches = rx.Matches(value.ToString());

            if (matches.Count > 0)
            {
                return null;
            }

            return new ValidationResult("You should use a valid name");
        }
    }
}
