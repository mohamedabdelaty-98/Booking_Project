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
            return PartialView("_insertimaghotelPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult insert(Image_Hotel image, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // file name + new guid --> guarntee that if the user upload imagae with the same name and extension to be stored in wwwroot 
                var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                var extension = Path.GetExtension(imageFile.FileName);
                var fullpath = fileName + Guid.NewGuid() + extension;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fullpath);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                image.ImageURL = "/images/" + fullpath;
                images.insert(image);
                images.save();
                return RedirectToAction("index","admin");
            }

            return PartialView("_insertimaghotelPartial", image);
        }




    }
}
