using AutoMapper;
using Booking_Project.Models;
using Booking_Project.ViewModels;
using Booking_Project1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Booking_Project.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationIdentityUser> userManager;
        private readonly SignInManager<ApplicationIdentityUser> signInManager;

        public AccountController(IMapper mapper,UserManager<ApplicationIdentityUser> userManager,
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
        public IActionResult Register(string ReturnUrl = "/home/index")
        {
            ViewData["page"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterAccountVM registerAccountVM, string ReturnUrl = "/home/index")
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

                    //cookie -token ...
                    await signInManager.SignInAsync(applicationIdentity, false);
                    return LocalRedirect(ReturnUrl);
                }
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View(registerAccountVM);
        }
        public IActionResult Login(string ReturnUrl = "/home/index")
        {
            if (User.IsInRole("Admin"))
            {
                ReturnUrl = "/Admin/Index";
            }

            ViewData["page"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginAccountVM accountVM, string ReturnUrl = "/home/index")
        {
            if (ModelState.IsValid)
            {
                ApplicationIdentityUser applicationIdentity =
                    await userManager.FindByEmailAsync(accountVM.Email);
                if (applicationIdentity != null)
                {
                    var result =
                        await signInManager.PasswordSignInAsync(applicationIdentity, accountVM.PasswordHash, accountVM.Remmberme, false);
                    if (result.Succeeded)
                    {

                        List<string> Adminmails =await GetAdminEmails();
                        bool checkisadmin= Adminmails.Any(item=>item==applicationIdentity.Email);
                        if (checkisadmin)
                        {
                            await signInManager.SignInAsync(applicationIdentity, accountVM.Remmberme);
                            ReturnUrl = "/admin/index";
                            return LocalRedirect(ReturnUrl);
                        }
                        else
                        {
                            await signInManager.SignInAsync(applicationIdentity, accountVM.Remmberme);
                            return LocalRedirect(ReturnUrl);
                        }

                    }
                    ModelState.AddModelError("", "Email or password is invalid");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is invalid");
                }
            }
            return View();
        }
        //check if login is admin
        public async Task<List<string>> GetAdminEmails()
        {
            string adminRole = "Admin"; 

            IList<ApplicationIdentityUser> adminUsers =await userManager.GetUsersInRoleAsync(adminRole);

            List<string> adminEmails = adminUsers.Select(user => user.Email).ToList();

            return adminEmails;
        }

        public IActionResult SignOut() 
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public async Task<bool> CheckEmial(string Email)
        {
            ApplicationIdentityUser applicationIdentity=
                await userManager.FindByEmailAsync(Email);
            if (applicationIdentity == null)
                return false;
            return true;
        }
        public bool CheckPassword(string PasswordHash)
        {
            Regex pattern = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=!]).+$");
            return pattern.IsMatch(PasswordHash);
        }
    }
}
