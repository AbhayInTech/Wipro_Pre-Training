using System.ComponentModel.DataAnnotations;

namespace EF_DB_Connect_Demo.Modules
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }
        [Required]
        [StringLength(100)]
        public required string TrainerName { get; set; }
        public required string Expertise { get; set; }
    }
}