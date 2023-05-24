using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopPanel.Business.Services.Abstract;
using ShopPanel.Entity.DTOs.Products;

namespace ShopPanel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IStoreService storeService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IStoreService storeService, IMapper mapper)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.storeService = storeService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAllProductsWithCategoryNonDeletedAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var stories = await storeService.GetAllStoresWithNonDeleted();
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ProductAddDto { Categories = categories, Stores = stories });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            await productService.CreateProductAsync(productAddDto);
            RedirectToAction("Index", "Product", new { Area = "Admin" });

            var stories = await storeService.GetAllStoresWithNonDeleted();
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ProductAddDto { Categories = categories, Stores = stories });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid productId)
        {
            var product = await productService.GetProductWithCategoryNonDeletedAsync(productId);
            var stories = await storeService.GetAllStoresWithNonDeleted();
            var categories = await categoryService.GetAllCategoriesNonDeleted();

            var productUpdateDto = mapper.Map<ProductUpdateDto>(product);
            productUpdateDto.Categories = categories;
            productUpdateDto.Stores = stories;

            return View(productUpdateDto);
        }


        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await productService.UpdateProductAsync(productUpdateDto);

            //var product = await productService.GetProductWithCategoryNonDeletedAsync(productId);
            var stories = await storeService.GetAllStoresWithNonDeleted();
            var categories = await categoryService.GetAllCategoriesNonDeleted();

            productUpdateDto.Categories = categories;
            productUpdateDto.Stores = stories;

            return View(productUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid productId)
        {
            await productService.SafeDeleteProductAsync(productId);

            return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }
    }
}
