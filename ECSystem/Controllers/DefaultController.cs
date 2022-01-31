using ECSytem.Helper;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECSytem.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IUserRepository _repo;
        public DefaultController(IUserRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(Login model)
        {
            try
            {
                User user = await _repo.GetByUserNameAsync(model.Username, model.Password.Base64Encode());
                if (user != null)
                {
                    List<Claim> userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim(ClaimTypes.Email, model.Username),
                        new Claim(ClaimTypes.Role, user.IsAdmin ? RoleOption.Admin : RoleOption.Customer),
                    };

                    var grandmaIdentity = new ClaimsIdentity(userClaims, user.IsAdmin ? RoleOption.Admin : RoleOption.Customer);
                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    await HttpContext.SignInAsync(userPrincipal);
                    if (user.IsAdmin)
                    {
                        return Redirect("/Admin/Home/Index");
                    }

                    return Redirect("/Customer/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("ValidationErrors", "Invalid username or password.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
