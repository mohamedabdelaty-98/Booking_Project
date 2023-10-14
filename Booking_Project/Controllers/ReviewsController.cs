using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class ReviewsController : Controller
    {
       private readonly ICrudOperation<Reviews> crud;
        private readonly ICrudOperation<ApplicationIdentityUser> user;
        private readonly ICrudOperation<Hotel> hotel;

        public ReviewsController(ICrudOperation<Reviews> crud,ICrudOperation<ApplicationIdentityUser>user, ICrudOperation<Hotel> hotel)
        {
            this.crud = crud;
            this.user = user;
            this.hotel = hotel;
        }
        public IActionResult details( int id)
        {
          
            return View("details", crud.GetById(id));
        }
        public IActionResult index()
        { 
       
            return View("index", crud.GetAll(h=>new { h.hotel ,h.user}));
        }
        public IActionResult New() 
        {
            ViewData["hotellist"] = hotel.GetAll();
            ViewData["userlist"] = user.GetAll();

            return View("New");
            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Reviews res)
        {
            if(ModelState.IsValid==true)
            {
                crud.insert(res);
                crud.save();
                return RedirectToAction("Index");
            }
            return View("New");
        }
    }
}
