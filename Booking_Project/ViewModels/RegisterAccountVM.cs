using System.ComponentModel.DataAnnotations;

namespace Booking_Project.ViewModels
{
    public class RegisterAccountVM : AuthenticationCLass
    {
        [Required]
        public string  UserName { get; set; }
        [Required]
        [RegularExpression(@"^[^\d]*$",ErrorMessage ="Enter Valid Name")]
        [MinLength(4,ErrorMessage ="Lenght must be greater than 4")]
        public string Fname { get; set; }
        [Required]
        [RegularExpression(@"^[^\d]*$", ErrorMessage = "Enter Valid Name")]
        [MinLength(4, ErrorMessage = "Lenght must be greater than 4")]
        public string Lname { get; set; }
        [Required]
        [Compare("PasswordHash",ErrorMessage ="Password Not Matched")]
        [DataType(DataType.Password)]
        public string ConfiremPassword { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^(010|011|015|012)\d{8}$",ErrorMessage ="Enter Valid PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required]
        public int gender { get; set; }
    }
}
