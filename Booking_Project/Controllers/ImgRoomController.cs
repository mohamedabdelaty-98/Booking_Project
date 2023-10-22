using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class ImgRoomController : Controller
    {
        ICrudOperation<Image_Room> Images;
        ICrudOperation<Room> Rooms;
        public ImgRoomController(ICrudOperation<Image_Room> Images, ICrudOperation<Room> Rooms)
        {
            this.Images = Images;
            this.Rooms = Rooms;
        }
        public IActionResult Insert()
        {
            ViewData["Rooms"] = Rooms.GetAll();
            return PartialView("_InsertImageRoomPartial");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Image_Room image, IFormFile imageFile)
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
                Images.insert(image);
                Images.save();
                return RedirectToAction("getall", "hotel");
            }

            return PartialView("_InsertImageRoomPartial", image);
        }
    }
}
