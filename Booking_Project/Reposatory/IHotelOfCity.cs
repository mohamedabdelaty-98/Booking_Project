using Booking_Project.Models;

namespace Booking_Project.Reposatory
{
    public interface IHotelOfCity
    { 
        public  List<Hotel> GetByCity (string city);
    }
}
