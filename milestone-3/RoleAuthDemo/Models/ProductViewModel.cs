using System.ComponentModel.DataAnnotations;

namespace RoleAuthDemo.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
