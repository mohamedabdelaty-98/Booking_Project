using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking_Project.ViewModels
{
    public class LoginAccountVM :AuthenticationCLass
    {
        [Required(ErrorMessage ="Email is Required")]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]+@(gmail\.com|yahoo\.com|outlook\.com|hotmail\.com)\b",
           ErrorMessage = "pleas enter valid email ")]
        [Remote("CheckEmial","Account",ErrorMessage ="You are not Register")]
        public string Email { get; set; }
        public bool Remmberme { get; set; }
    }
}
