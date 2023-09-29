using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReservationId { get; set; }
        [Column (TypeName ="date")]
        public DateTime PaymentDate { get; set; }
        [Column (TypeName ="Money")]
        public decimal PaymentAmount { get; set; }
       // public string PaymentMethod { get; set; }
    }
}
