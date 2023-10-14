using AutoMapper;
using Booking_Project.Models;
using Booking_Project.ViewModels;

namespace Booking_Project.Reposatory
{
    public class AutomapperProfile : Profile 
    {
        public AutomapperProfile()
        {
            CreateMap<RegisterAccountVM, ApplicationIdentityUser>();
           
        }
    }
}
