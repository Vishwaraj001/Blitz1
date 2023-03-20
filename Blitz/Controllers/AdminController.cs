using Blitz.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blitz.Controllers
{
    public class AdminController : Controller
    {
        IAdminRepository _adminRepository;
        public AdminController(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;   
        }
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminModel adminModel)
        {
            bool loginStatus = _adminRepository.CheckAdminLogin(adminModel);

            if (loginStatus == true)
            {
               return RedirectToAction("ProductDetails", "Product");
                //ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Success No";

            }
            return View();
        }
    }
}
