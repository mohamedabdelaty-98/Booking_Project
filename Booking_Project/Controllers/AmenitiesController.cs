using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]

        public IActionResult insert()
        {
            return PartialView("_insertPartialAmenties");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public IActionResult insert (Amenities amenity)
        {
            if (ModelState.IsValid)
            {
                amenities.insert(amenity);
                amenities.save();
                return RedirectToAction("index", "admin");

            }

            return PartialView("_insertPartialAmenties", amenity);
        }

        public IActionResult getall() {

            List<Amenities> amenety= amenities.GetAll();
        
            return PartialView("_getallaminties",amenety);
        
        }
        [Authorize(Roles = "Admin")]

        public IActionResult getAmenity (int id)
        {
            Amenities amenity = amenities.GetById(id);
            return PartialView("_editeAmentyPartial", amenity);
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Update (Amenities amenity)
        {
            amenities.update(amenity);
            amenities.save();

           return RedirectToAction("index","admin");
        }
        [Authorize(Roles = "Admin")]

        public IActionResult delete (int id)
        {
            amenities.Delete(id);
            amenities.save();
            return RedirectToAction("index","admin");
        }

       
    }
}
