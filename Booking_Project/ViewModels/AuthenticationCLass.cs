using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking_Project.ViewModels
{
    public class AuthenticationCLass
    {
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="lenght must be greater than 8 letter")]
        [Remote("CheckPassword","Account",ErrorMessage ="Must contain uppercase, lowercase,numbers and special charachter")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]+@(gmail\.com|yahoo\.com|outlook\.com|hotmail\.com)\b",
            ErrorMessage ="pleas enter valid email ")]
        //ckeckemail
        public string Email { get; set; }

    }
}
