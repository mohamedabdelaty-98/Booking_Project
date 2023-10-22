using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public class Image_Hotel
    {
        public int Id { get; set; }
 //[Column(TypeName = "byte")]
 public string ImageURL { get; set; }
 [MaxLength(1000)]
 public string Description { get; set; }
 [ForeignKey("hotel")]

 public int HotelId { get; set; }
 public virtual Hotel hotel { get; set; }



    }
}
