using Microsoft.AspNetCore.Mvc;
using ShopPanel.Business.Services.Abstract;
using ShopPanel.Models;
using System.Diagnostics;

namespace ShopPanel.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProductService productService;

		public HomeController(ILogger<HomeController> logger, IProductService productService)
		{
			_logger = logger;
			this.productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			var products = await productService.GetAllProductsWithCategoryNonDeletedAsync();
			return View(products);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}