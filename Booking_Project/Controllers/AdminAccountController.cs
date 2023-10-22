using AutoMapper;
using Booking_Project.Models;
using Booking_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class AdminAccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationIdentityUser> userManager;
        private readonly SignInManager<ApplicationIdentityUser> signInManager;

        public AdminAccountController(IMapper mapper, UserManager<ApplicationIdentityUser> userManager,
            SignInManager<ApplicationIdentityUser> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddAdmin(string ReturnUrl = "/admin/index")
        {
            ViewData["page"] = ReturnUrl;
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterAccountVM registerAccountVM, string ReturnUrl = "/admin/index")
        {
            if (ModelState.IsValid)
            {
                //Mapping 
                ApplicationIdentityUser applicationIdentity =
                    mapper.Map<ApplicationIdentityUser>(registerAccountVM);
                IdentityResult result =
                    await userManager.CreateAsync(applicationIdentity, registerAccountVM.PasswordHash);
                if (result.Succeeded)
                {
                    await  userManager.AddToRoleAsync(applicationIdentity, "Admin");
                    //cookie -token ...
                    await signInManager.SignInAsync(applicationIdentity, false);
                    return LocalRedirect(ReturnUrl);
                }
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View("Register", registerAccountVM);
        }
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("login","account");
        }
    }
}
