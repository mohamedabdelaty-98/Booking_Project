using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class ReservationRoom
    {
        public int Id { get; set; }
        public int NumOfGuest { get; set; }
        [Column(TypeName ="date")]
        public DateTime CheckinDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }
        [ForeignKey("reservations")]
        public int ReservationId { get; set; }
        public Reservations reservations { get; set; }
        [ForeignKey("room")]
        public int RoomId { get; set; }
        public Room room { get; set; }
    }
}
