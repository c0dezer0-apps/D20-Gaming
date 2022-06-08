using System.ComponentModel.DataAnnotations;

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
}
