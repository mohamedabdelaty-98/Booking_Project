using AutoMapper;
using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Booking_Project.Models;
using Booking_Project.Reposatory;

namespace Booking_Project.Controllers
{

    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        private readonly ICrudOperation<ApplicationIdentityUser> user_Data;
        private readonly ICrudOperation<Image_Hotel> img_hotel;
         private readonly ICrudOperation<Room> RoomRepo;
        private readonly ICrudOperation<Hotel> hotelrepo;
        IHotelOfCity hotels;

        private readonly IMapper mapper;
        static int counter=0;
        int number_of_images ;
        public AdminController(ICrudOperation<ApplicationIdentityUser> user_data,
            ICrudOperation<Image_Hotel> img_hotel, IMapper mapper, IHotelOfCity hotels, ICrudOperation<Room> RoomRepo,ICrudOperation<Hotel> hotelRepo)
        {
            this.img_hotel = img_hotel;
            //user_Da = user_da;
            user_Data = user_data;
            this.mapper = mapper;
             this.RoomRepo = RoomRepo;
            this.hotelrepo = hotelRepo;
            this.hotels = hotels;
        }

        public IActionResult Index(){
            return View();
        }


        public IActionResult Reservations()
{
        
            return View("AllReservations");
        }


        public IActionResult Rooms()
        {
            List<Room> RoomModel = RoomRepo.GetAll(h=>h.hotel);
           
            return View("room",RoomModel);
        }
        public IActionResult EditRoom(int id)
        {
            Room rs = RoomRepo.GetById(id);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("EditRoom", rs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoom(Room rs, int id)
        {
            if (rs.room_number != null)
            {
                RoomRepo.update(rs);
                RoomRepo.save();
                return RedirectToAction("Rooms");
            }
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("EditRoom", rs);
        }
        public IActionResult DeleteRoom(int id)
        {
            RoomRepo.Delete(id);
            RoomRepo.save();
            return RedirectToAction("Rooms");
        }
        public IActionResult NewRoom()
        {
            //List<Room> RoomModel = RoomRepo.GetAll(h => h.hotel);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("new");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                RoomRepo.insert(room);
                RoomRepo.save();
                return RedirectToAction("Rooms");
            }
            List<Room> RoomModel = RoomRepo.GetAll(h => h.hotel);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("new", room);
        }

        public IActionResult Show()
        {
            

            return View(user_Data.GetAll(e => e.reservations));
        }

        
        public IActionResult Slider()
        {
            //    List<Image_Hotel> images = new List<Image_Hotel>();
            //    Image_Hotel item;

            //    for (int i = 1; i<=12; i++)
            //    {
            //        item = new Image_Hotel();
            //        item.Id = i;
            //        item.ImageURL = $"hh/{i}.jpg";
            //        images.Add(item);


            //    }
            //    counter++;
            //    if (counter > number_of_images-5)
            //    {
            //        counter = 1;
            //    }

            counter++;
            if (counter > number_of_images - 5)
                   {
                        counter = 1;
                    }
                ViewBag.ia = counter;

            return View(img_hotel.GetAll(e=>e.hotel));
        }
        public IActionResult hotelsCity(string city)
        {
            List<Hotel> hotelsCity = hotels.GetByCity(city);
            return View(hotelsCity);
        }

    }
}
