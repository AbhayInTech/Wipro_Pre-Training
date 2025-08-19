using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        
        [Required(ErrorMessage = "Published Date is required")]
        public DateTime PublishedDate { get; set; }
        
        public decimal Price { get; set; }
    }
}
