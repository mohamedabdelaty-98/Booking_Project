using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class ReservationsController : Controller
    {
        ICrudOperation<Reservations> Reservations;
        public ReservationsController(ICrudOperation<Reservations> Reservations)
        {
            this.Reservations = Reservations;
        }
        public IActionResult GetAll()
        {
            
            return View(Reservations.GetAll(R=>R.user));
        }
        public IActionResult GetbyId(int id) { 
        
            Reservations.GetById(id);
            return View();
        }
        public IActionResult AddReservation() {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReservation(Reservations reservation) {
            Reservations.insert(reservation);
            Reservations.save();
            return RedirectToAction("GetAll");
        
        }
        public IActionResult EditReservation(int id)
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditReservation(Reservations reservation) {

            Reservations.update(reservation);
            Reservations.save();
            return RedirectToAction("GetAll");
        }
        public IActionResult DeleteReservation(int id)
        {
            Reservations.Delete(id);
            Reservations.save();
            return RedirectToAction("GetAll");

        }
    }
}
