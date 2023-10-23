using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Authorization;
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
            return PartialView("_ReservationPartial", Reservations.GetAll(R => R.user,s=>s.reservationRooms)) ;
        }
        [Authorize(Roles = "Admin")]

        public IActionResult GetbyId(int id) { 
        
            Reservations.GetById(id);
            return View();
        }
        [Authorize(Roles = "Admin")]

        public IActionResult AddReservation() {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public IActionResult AddReservation(Reservations reservation) {
            Reservations.insert(reservation);
            Reservations.save();
            return RedirectToAction("GetAll");
        
        }
        [Authorize(Roles = "Admin")]

        public IActionResult EditReservation(int id)
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public IActionResult EditReservation(Reservations reservation) {

            Reservations.update(reservation);
            Reservations.save();
            return RedirectToAction("GetAll");
        }
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteReservation(int id)
        {
            Reservations.Delete(id);
            Reservations.save();
            return RedirectToAction("GetAll");

        }
    }
}
