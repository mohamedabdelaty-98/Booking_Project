using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class AmenitiesController : Controller
    {
        ICrudOperation<Amenities> amenities;

        public AmenitiesController( ICrudOperation<Amenities> amenities)
        {
            this.amenities = amenities; 
        }
        public IActionResult insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult insert (Amenities amenity)
        {
            if (ModelState.IsValid)
            {
                amenities.insert(amenity);
                amenities.save();
                return RedirectToAction("insert");

            }

            return View("insert", amenity);
        }

        public IActionResult getall() {

            List<Amenities> amenety= amenities.GetAll();
        
            return View(amenety);
        
        }

        public IActionResult getAmenity (int id)
        {
            Amenities amenity = amenities.GetById(id);
            return View(amenity);
        }

        public IActionResult Update (Amenities amenity)
        {
            amenities.update(amenity);
            amenities.save();

           return RedirectToAction("getAll");
        }

        public ActionResult delete (int id)
        {
            amenities.Delete(id);
            amenities.save();
            return RedirectToAction("getAll");
        }

       
    }
}
