// Adding data validation for validation purposes

using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Product
    {
        public int Id { get; set; }



        [Required (ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;



        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;



        [Range(0.01, 10000.00, ErrorMessage = "Price must be between Rs 0.01 and Rs 10,000.00.")]
        public decimal Price { get; set; }
    }
}
