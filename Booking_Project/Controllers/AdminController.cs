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
        private readonly ICrudOperation<Image_Hotel> img_hotel;

        private readonly IMapper mapper;
        static int counter=0;
        int number_of_images ;
        public AdminController(ICrudOperation<ApplicationIdentityUser> user_data,
            ICrudOperation<Image_Hotel> img_hotel, IMapper mapper)
        {
            this.img_hotel = img_hotel;
            //user_Da = user_da;
            user_Data = user_data;
            this.mapper = mapper;
             number_of_images = img_hotel.GetAll().Count;

        }
        public IActionResult Index()
        {
            return View();
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
        
    }
}
