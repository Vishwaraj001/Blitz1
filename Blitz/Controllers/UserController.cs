using Microsoft.AspNetCore.Mvc;
using Blitz.Models;
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
            UserModel ordersModel = _userRepository.AddUser(orders);
           // return RedirectToAction("OrderDetails");
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
                ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Success No";

            }
            return View();
        }

    }
}
