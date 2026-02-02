using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Teachers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [StringLength(150)]
        public string? Address { get; set; }

        [StringLength(10)]
        public string? Phone { get; set; }

        public byte? Age { get; set; }

        [DataType(DataType.Date)]

        public DateOnly? BirthDate { get; set; }
    }
}
