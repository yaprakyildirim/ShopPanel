using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopPanel.Business.Services.Abstract;

namespace ShopPanel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAllProductsWithCategoryNonDeletedAsync();
            return View(products);
        }
    }
}