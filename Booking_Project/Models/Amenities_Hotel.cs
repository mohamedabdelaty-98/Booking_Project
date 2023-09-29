using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class Amenities_Hotel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int AmenitiesId { get; set; }
        [Column (TypeName ="money")]
        public decimal Price { get; set; }


    }
}
