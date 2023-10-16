using System.ComponentModel.DataAnnotations;

namespace Booking_Project.Models
{
    public class Amenities
    {
        public Amenities()
        {
            amenitiesRooms = new List<AmenitiesRoom>();
            amenities_Hotels = new List<Amenities_Hotel>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual List<Amenities_Hotel>? amenities_Hotels { get; set; }
        public virtual List<AmenitiesRoom>? amenitiesRooms { get; set; }
    }
}