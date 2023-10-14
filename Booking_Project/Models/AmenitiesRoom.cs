using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class AmenitiesRoom
    {
        public int Id { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [ForeignKey("room")]
        public int RoomId { get; set; }
        public Room room { get; set; }
        [ForeignKey("amenities")]
        public int AmentiesId { get; set; }
        public Amenities? amenities { get; set; }

    }
}