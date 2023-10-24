using AutoMapper;
using Booking_Project.Models;
using Booking_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddROle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddROle(AddRoleVm addRoleVm)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name=addRoleVm.Name};
                IdentityResult result=await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View();
                }
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View(addRoleVm);
        }
        
    }
}
