using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class ImgHotelController : Controller
    {
        ICrudOperation<Image_Hotel> images;
        ICrudOperation<Hotel> hotels;

        public ImgHotelController(ICrudOperation<Image_Hotel> images, ICrudOperation<Hotel> hotels)
        {
            this.images = images;
            this.hotels = hotels;

        }


        public IActionResult insert()
        {
            ViewData["hotels"] = hotels.GetAll();
            return View();
        }




    }
}
