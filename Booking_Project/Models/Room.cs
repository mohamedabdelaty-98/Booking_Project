using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public enum AvailableStatus
    {
        available, unavailable
    }

    public enum RoomType
    {
        Single, Double, Triple, suite
    }
    public class Room
    {
        public Room()
        {
            image_Rooms = new List<Image_Room>();
            aminitesRooms = new List<AmenitiesRoom>();
            reservationRooms = new List<ReservationRoom>();
        }
        
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public RoomType RoomType { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int NumOfBed { get; set; }
        public int MaxOccupancy { get; set; }
        public double RoomSize { get; set; }
        [Column(TypeName = "varchar(10)")]
        public  AvailableStatus AvailableStatus { get; set; }
        public int room_number { get; set; }
       [ DefaultValue(1)]     
       [ForeignKey("hotel")]
        public int HotelId { get; set; }
        public virtual Hotel hotel { get; set; }
        public virtual List<Image_Room> image_Rooms { get; set; }
        public virtual List<AmenitiesRoom> aminitesRooms { get; set; }
        public virtual List<ReservationRoom> reservationRooms { get; set; }

    }
}