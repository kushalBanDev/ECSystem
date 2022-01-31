using ECSytem.Helper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System;
using System.Threading.Tasks;

namespace ECSytem.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SignupController : Controller
    {
        private readonly IUserRepository _repo;
        public SignupController(IUserRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string Message)
        {
            var TempMsg = TempData["Message"];
            ViewBag.Message = TempMsg;
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Save(User model)
        {
            try
            {
                model.Password = model.Password.Base64Encode();
                await _repo.SaveAsync(model);

                ViewBag.Success = true;
                string Message = "Account Created Successfully.";
                TempData["Message"] = Message;
                return RedirectToAction("Signup", "Customer");
            }
            catch (Exception ex)
            {
                ViewBag.Success = false;
                ViewBag.ErrorMessage = ex.Message;
            }
             return RedirectToAction("Signup", "Customer");
        }
    }
}
