using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        [MaxLength(1000)] 
        public string  ReviewText { get; set; }
        [Column (TypeName ="date")]
        public DateTime DatePosted { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public User user { get; set; }
        [ForeignKey("hotel")]
        public int HotelId { get; set; }
        public Hotel hotel { get; set; }
    }
}
