using Booking_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using Booking_Project.Reposatory;
using Microsoft.Extensions.FileProviders.Physical;
using static System.Net.Mime.MediaTypeNames;

namespace Booking_Project.Controllers
{
    public class HotelImagesController : Controller
    {
        ICrudOperation<Image_Hotel> hotel_images;
        public HotelImagesController(ICrudOperation<Image_Hotel> hotel_images)
        {
            this.hotel_images = hotel_images;
        }
        public IActionResult Index()
        {
            return View("uploadimage");
        }

        [HttpPost]
    
        public ActionResult UploadImage(Image_Hotel image, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // file name + new guid --> guarntee that if the user upload imagae with the same name and extension to be stored in wwwroot 
                var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                var extension = Path.GetExtension(imageFile.FileName);
                var fullpath = fileName + Guid.NewGuid() + extension;
              
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images", fullpath);
              
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                image.ImageURL = "/images/" + fullpath;
                hotel_images.insert(image);
                hotel_images.save();
                return RedirectToAction("Index");
            }

            return View();
        }
        //public IActionResult DisplayImages()
        //{
        //    return View();
        //}
        ////public IActionResult Images()
        ////{
        ////    // Construct the full path to the image based on the stored imagePath
        ////    List<Image_Hotel> images = hotel_images.GetAll();

        ////    foreach (var image in images)
        ////    {
        ////        var imagePathOnServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.ImageURL);
        ////        // Check if the file exists
        ////        if (System.IO.File.Exists(imagePathOnServer))
        ////        {
        ////            // Return the image with the appropriate MIME type
        ////            return PhysicalFile(imagePathOnServer, "image/jpg"); // Change the MIME type as needed
        ////        }
        ////      //  return NotFound();

        ////    }


        ////    return RedirectToAction("Index");

        ////}

    }
}


