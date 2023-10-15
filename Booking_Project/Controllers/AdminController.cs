using AutoMapper;
using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ICrudOperation<ApplicationIdentityUser> user_Data;
        private readonly IMapper mapper;

        public AdminController(ICrudOperation<ApplicationIdentityUser> user_data, IMapper mapper)
        {
            user_Data = user_data;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show()
        {
            //user_Data.GetAll().ToList();
            //ViewBag.how = user_Data.GetAll(e => e.reservations, w => w.reviews, a => a.payments);
            //ViewBag.how = user_Data.GetAll(e => e.reservations);

            return View(user_Data.GetAll(e=>e.reservations,s=>s.reviews));
        }
        public IActionResult details()
        {
            return View();
        }
    }
}
