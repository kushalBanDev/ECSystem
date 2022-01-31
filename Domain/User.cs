using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("User")]
    public class User : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z ]{2,30} [a-zA-Z]{2,30}$", ErrorMessage = "Only valid for A-Z,a-z,0-9,.,_. Length must be 3-15 letters")]
        [Required(ErrorMessage = "Buyer name is required")]
        [Display(Name = "Buyers Name")]
        public string BuyerName { get; set; }

        [Required(ErrorMessage = "Buyer phone is required")]
        [Display(Name = "Buyers Phone")]
        public string BuyerPhone { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Username must be between 5 to 50 character long.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 to 50 character long.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Confirm Password must be between 8 to 50 character long.")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password did not matched")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool IsAdmin { get; set; } = false;

        [Display(Name = "Doing Business As")]
        public string DoingBusinessAs { get; set; }

        public string School { get; set; }

        [Required]
        public StatusOption Status { get; set; } = StatusOption.Active;

        [Required]
        public CustomerTypeOption CustomerType { get; set; } = CustomerTypeOption.Student;
        public ShippingOption ShippingMethod { get; set; } = ShippingOption.None;
    }
    public class BaseClass
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z ]{2,30} [a-zA-Z]{2,30}$", ErrorMessage = "Only valid for A-Z,a-z,0-9,.,_. Length must be 3-15 letters")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "First Name must be between 3 to 256 character long.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Address must be between 1 to 50 character long.")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string Phone { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Email must be between 1 to 256 character long.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Fax { get; set; }
    }
}
