using Booking_Project.Models;
using Booking_Project.Reposatory;
using Booking_Project1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class HotelController : Controller 
    {
        ICrudOperation<Hotel> Ihotel;

        public HotelController( ICrudOperation<Hotel> hotel)
        {
            this.Ihotel = hotel;
        }

        public IActionResult insert()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult insert (Hotel hotel)
        {
          if (ModelState.IsValid)
            {

                Ihotel.insert(hotel);
                Ihotel.save();
                return RedirectToAction("insert");
            }
                return View("insert", hotel);
        }

       
        public IActionResult getAll()
        {

             List<Hotel> hotels=Ihotel.GetAll();
            return View(hotels);
        }


        public IActionResult getHotel (int id)
        {
           Hotel hotel = Ihotel.GetById(id);

            return View("getHotel" , hotel);

        }

        public IActionResult update(Hotel hotel)
        {
            Ihotel.update(hotel);
            Ihotel.save();

            return RedirectToAction("getAll");
        }
        
        public IActionResult delete(int id)
        {
            Ihotel.Delete(id);
            Ihotel.save();
            return RedirectToAction("getAll");
        }


    }
}
