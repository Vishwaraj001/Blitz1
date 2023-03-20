using Microsoft.AspNetCore.Mvc;
using Blitz.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blitz.Controllers
{
    public class UserController : Controller
    {

        IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        } 
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel orders)
        {
            ViewBag.Button = "BUTTON CODE";
           ViewBag.FName = orders.FirstName; 
           ViewBag.LastName=orders.LastName;
            ViewBag.EmailId = orders.U_EmailId;
            ViewBag.mobile = orders.U_MobileNumber;
            ViewBag.pass = orders.U_Password;
            // ViewBag.Message = "SUBMIT";

             UserModel ordersModel = _userRepository.AddUser(orders);
            return RedirectToAction("Login");
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Login(UserModel userModel)
        {   
            bool loginStatus = _userRepository.CheckUserLogin(userModel);

            if (loginStatus == true)
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userModel.U_EmailId) },
                CookieAuthenticationDefaults.AuthenticationScheme); var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetString("Email", userModel.U_EmailId);
                return RedirectToAction("ProductDetails", "Product");
                

            }
            else
            {
                ViewBag.Message = "Success No";

            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public IActionResult HomePage() { return View(); }

    }
}
