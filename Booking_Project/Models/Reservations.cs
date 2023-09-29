using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        [Column(TypeName = "date")]

        public DateTime CheckInDate { get; set; }
        [Column(TypeName = "date")]

        public DateTime CheckOutDate { get; set;}
        [Column (TypeName ="Money")]
        public decimal TotalPrice { get; set; }
       // public AvailableStatus Status { get; set; }  
      //  public string PaymentMethod { get; set; }   

    }
}
