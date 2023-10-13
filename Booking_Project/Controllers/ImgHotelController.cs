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
        public async Task<IActionResult> insert(Image_Hotel img, IFormFile ImageURL)
        {
            if (ModelState.IsValid)
            {

                if (ImageURL.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await ImageURL.CopyToAsync(stream);
                        // You can save, process, or store the image data here
                        img.ImageURL = stream.ToArray();

                    }
                }

                images.insert(img);
                images.save();


                return RedirectToAction("insert");

            }

            return View("insert", img);

        }


        //public async Task<IActionResult> insert(Image_Hotel img, IFormFile ImageURL)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (ImageURL.Length > 0)
        //        {
        //            using (var reader = new StreamReader(ImageURL.OpenReadStream()))
        //            {
        //                img.ImageURL = await reader.ReadToEndAsync();
        //            }

        //            images.insert(img);
        //            images.save();

        //            return RedirectToAction("insert");
        //        }
        //    }

        //    return View("insert", img);
        //}


        //public async Task<IActionResult> Insert(Image_Hotel img, IFormFile ImageURL)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (ImageURL.Length > 0)
        //        {
        //            using (var stream = new MemoryStream())
        //            {
        //                await ImageURL.CopyToAsync(stream);
        //                byte[] imageBytes = stream.ToArray();
        //                img.ImageURL = Convert.ToBase64String(imageBytes);
        //            }

        //            images.insert(img);
        //            images.save();

        //            return RedirectToAction("Insert");
        //        }
        //    }

        //    return View("Insert", img);
        //}




    }
}
