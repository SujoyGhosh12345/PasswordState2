using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models
{
    public class Passwords
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
