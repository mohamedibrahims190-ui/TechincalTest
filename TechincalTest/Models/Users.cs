using System.ComponentModel.DataAnnotations;

namespace TechincalTest.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Role { get; set; }
    }
}
