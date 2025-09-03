using System.ComponentModel.DataAnnotations;

namespace Assignment2MvcApp.Models
{
    /// <summary>
    /// User model demonstrating simple and complex model binding
    /// This model represents a user with basic information and nested address details
    /// </summary>
    public class User
    {
        // Simple type properties for model binding
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        // Complex type property - nested model for model binding
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public Address Address { get; set; } = new Address();

        /// <summary>
        /// Computed property to get full name
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";
    }

    /// <summary>
    /// Address model demonstrating complex/nested model binding
    /// This represents the nested model within the User model
    /// </summary>
    public class Address
    {
        [Required(ErrorMessage = "Street is required")]
        [Display(Name = "Street Address")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zip code is required")]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid zip code format")]
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// Computed property to get full address
        /// </summary>
        public string FullAddress => $"{Street}, {City}, {ZipCode}";
    }
}
