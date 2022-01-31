using Domain;
using ECSytem.Helper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Threading.Tasks;

namespace ECSystem.Areas.Customer.Controllers
{
    [Area("Customer")]
    [AuthorizeUser(RoleOption.Customer)]
        public class BasketController : Controller
        {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<IActionResult> Index(int productId)
        {
            string userName = HttpContext.User.Identity.Name;
            Product result = await  _basketRepository.GetBasketProductsByCategoryId(userName, productId);


            var basketItemModel = new Basket
            {
                ProductId = result.Id,
                ProductDescription = result.Description,
                ProductCategoryId = result.Category,
                ProductUri = result.Image,
                ProductName = result.Name,
                ProductUnitPrice = result.Price

            };
            return View(basketItemModel);

        }
        public async Task<IActionResult> AddToBasket(Basket basket)
        {
            string userName = HttpContext.User.Identity.Name;
            basket.UserName = userName; 
            await _basketRepository.SaveAsync(userName, basket);
            return View(basket);
        }
    }
}
