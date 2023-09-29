using System.ComponentModel.DataAnnotations;

namespace Booking_Project.Models
{
    public class Amenities
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
