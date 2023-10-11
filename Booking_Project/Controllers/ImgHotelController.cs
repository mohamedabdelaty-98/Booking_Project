using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class ImgHotelController : Controller
    {
        ICrudOperation<Image_Hotel> images;
        ICrudOperation<Hotel> hotels;

        public ImgHotelController( ICrudOperation<Image_Hotel> images, ICrudOperation<Hotel> hotels)
        {
            this.images = images;
            this.hotels = hotels;
            
        }

        
        public IActionResult insert()
        {
            ViewData["hotels"]= hotels.GetAll();
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult insert(Image_Hotel img)
        {
            if (ModelState.IsValid)
            {
                images.insert(img);
                images.save();
                return RedirectToAction("getAll", "Hotel");

            }

            return View("insert", img);
           
        }
    }
}
