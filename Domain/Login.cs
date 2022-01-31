using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Login
    {
        [Required]
        [StringLength(50, ErrorMessage = "Username must be between 1 to 50 character long")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be between 1 to 50 character long")]
        public string Password { get; set; }
    }
}
