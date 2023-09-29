using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        [MaxLength(1000)] 
        
        public string  ReviewText { get; set; }
        [Column (TypeName ="date")]
        public DateTime DatePosted { get; set; }    

    }
}
