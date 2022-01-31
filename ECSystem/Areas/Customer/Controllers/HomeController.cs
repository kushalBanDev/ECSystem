using ECSytem.Helper;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECSytem.Areas.Customer.Controllers
{
    [Area("Customer")]
    [AuthorizeUser(RoleOption.Customer)]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;

        public HomeController(IProductRepository productRepository, IBasketRepository basketRepository)
        {
            _productRepository = productRepository;
            _basketRepository = basketRepository;

        }
        public async Task<IActionResult> Index(Product model)
        {
            var aaa = HttpContext.User.Identity.Name;
            IEnumerable<Product> lst = new List<Product>();
            if (string.IsNullOrEmpty(model.Category)) lst = await _productRepository.GetProductListAsync();
            else lst = await _productRepository.SearchProductByCategoryAsync(model.Category);
            ViewBag.DDLProduct = lst;
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
        public async Task<IActionResult> GetBasketItems(int productId)
        {
            return Json(new { success = true, response = "success." });
        }
    }
}
