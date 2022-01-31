using ECSytem.Helper;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECSytem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeUser(RoleOption.Admin)]
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
