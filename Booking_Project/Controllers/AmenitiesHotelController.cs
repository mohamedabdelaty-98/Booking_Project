using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class AmenitiesHotelController : Controller
    {
        ICrudOperation<Amenities_Hotel> amenitiesHotel;
        ICrudOperation<Amenities> amenities;
        ICrudOperation<Hotel> Hotels;



        public AmenitiesHotelController( ICrudOperation<Amenities_Hotel> amenityHotel, ICrudOperation<Hotel> hotel, ICrudOperation<Amenities> amenity)
        {

            this.amenitiesHotel = amenityHotel;
            this.amenities = amenity;
            this.Hotels = hotel;

        }
        public IActionResult insert()
        {
            ViewData["Hotels"] = Hotels.GetAll();
            ViewData["Amenities"] = amenities.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult insert(Amenities_Hotel amenities_Hotel)
        {
            if (ModelState.IsValid)
            {
                amenitiesHotel.insert(amenities_Hotel);
                amenitiesHotel.save();
                return RedirectToAction("insert");
            }
            return View(amenities_Hotel);
        }


        public IActionResult getAll()
        {
           List<Amenities_Hotel> amenityHotel  =amenitiesHotel.GetAll(a => a.amenities, a=>a.hotel);

            return View(amenityHotel);
        }

        public IActionResult getOnly (int id) {

            Amenities_Hotel amenities_Hotel = amenitiesHotel.GetById(id);
            ViewData["hotels"] = Hotels.GetById(amenities_Hotel.HotelId);
            ViewData["amenities"] = amenities.GetById(amenities_Hotel.AmentiesId);
            return View(amenities_Hotel);

        }

        public IActionResult update(Amenities_Hotel amenities)
        {
            amenitiesHotel.update(amenities);
            amenitiesHotel.save();
            return RedirectToAction("getAll");
        }

        public IActionResult delete (int id)
        {
            amenitiesHotel.Delete(id);
            amenitiesHotel.save();
            return RedirectToAction("getAll");
        }


    }
}
