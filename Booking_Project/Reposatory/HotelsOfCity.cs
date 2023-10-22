using Booking_Project.Models;
using Booking_Project1.Models;

namespace Booking_Project.Reposatory
{
    public class HotelsOfCity :IHotelOfCity
    {
        Context context;
        public HotelsOfCity(Context context)
        {
           this.context = context;
            
        }

        public List<Hotel> GetByCity(string city)
        {
            return context.Hotels.Where(h => h.Address == city).ToList();
        }
    }
}
