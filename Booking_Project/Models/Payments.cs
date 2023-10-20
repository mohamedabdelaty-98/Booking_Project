using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class Payments
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "Money")]
        public decimal PaymentAmount { get; set; }
        // public string PaymentMethod { get; set; }
        [ForeignKey("user")]
        public string UserId { get; set; }
        public ApplicationIdentityUser? user { get; set; }

        [ForeignKey("reservation")]
        public int? ReservationId { get; set; }
        public Reservations? reservation { get; set; }


    }
}