using System.ComponentModel.DataAnnotations;

namespace Booking_Project.ViewModels
{
    public class AddRoleVm
    {
        [Required]
        public string Name { get; set; }
    }
}
