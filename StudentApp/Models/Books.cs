using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Books 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

    }
}
