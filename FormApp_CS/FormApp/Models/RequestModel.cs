using System;
using System.ComponentModel.DataAnnotations;

namespace FormApp.Models
{
    public class RequestModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, MinimumLength = 100, ErrorMessage = "Description must be between 100 and 1000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        [DataType(DataType.Date)]
        [DateWithinOneYear(ErrorMessage = "The due date must be in the future but no more than one year from today")]
        public DateTime DueDate { get; set; }

        public RequestModel()
        {
            Email = "";
            Description = "";
            DueDate = DateTime.Now;
        }
    }
}

public class DateWithinOneYearAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime date;
        if (value is DateTime)
        {
            date = (DateTime)value;
        }
        else
        {
            return new ValidationResult("Invalid date value.");
        }

        // Check if the date is after today
        if (date <= DateTime.Today)
        {
            return new ValidationResult("Date must in the future.");
        }

        // Check if the date is within one year from today
        DateTime maxDate = DateTime.Today.AddYears(1);
        if (date > maxDate)
        {
            return new ValidationResult($"Date must be within one year from today.");
        }

        return ValidationResult.Success;
    }
}