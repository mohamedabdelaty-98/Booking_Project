using System.ComponentModel.DataAnnotations;

namespace Booking_Project.Models
{
    public class Hotel
    {
        public Hotel()
        {
            rooms = new List<Room>();
            amenities_Hotels = new List<Amenities_Hotel>();
            image_Hotels = new List<Image_Hotel>();
            reviews = new List<Reviews>();
            reservationRooms = new List<ReservationRoom>();
        }
        
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public decimal StarRateing { get; set; }
        [MaxLength(50)]
        public string ContactEmail { get; set; }
        [MaxLength(20)]
        public string ContactPhone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }


        public List<Room>? rooms { get; set; }
        public List<Image_Hotel>? image_Hotels { get; set; }
        public List<Amenities_Hotel>? amenities_Hotels { get; set; }
        public List<Reviews>? reviews { get; set; }
        public List<ReservationRoom> reservationRooms { get; set; }

    }
}
