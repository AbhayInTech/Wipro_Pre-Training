using System.ComponentModel.DataAnnotations;

namespace RoleAuthDemo.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PriceEncrypted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
