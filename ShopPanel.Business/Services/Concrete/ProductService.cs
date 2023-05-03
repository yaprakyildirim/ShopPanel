using AutoMapper;
using ShopPanel.Business.Services.Abstract;
using ShopPanel.DataAccess.UnitOfWorks;
using ShopPanel.Entity.DTOs.Products;
using ShopPanel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Business.Services.Concrete
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
		public async Task CreateProductAsync(ProductAddDto productAddDto)
		{
			var userId = Guid.Parse("E6C8D1CD-1B18-473A-B68A-7B3CB247307D");

			var product = new Product
			{
				ProductCode = productAddDto.ProductCode,
				ProductName = productAddDto.ProductName,
				Brand = productAddDto.Brand,
				Stock = productAddDto.Stock,
				CategoryId = productAddDto.CategoryId,
				StoreId = productAddDto.StoreId,
				UserId = userId
			};

			await unitOfWork.GetRepository<Product>().AddSync(product);
			await unitOfWork.SaveAsync();
		}

		public async Task<List<ProductDto>> GetAllProductsWithCategoryNonDeletedAsync()
		{
			var products = await unitOfWork.GetRepository<Product>().GetAllAsync(x => !x.IsDeleted, x => x.Category, x => x.Store);
			var map = mapper.Map<List<ProductDto>>(products);

			return map;
		}

		public async Task<ProductDto> GetProductWithCategoryNonDeletedAsync(Guid productId)
		{
			var product = await unitOfWork.GetRepository<Product>().GetAsync(x => !x.IsDeleted && x.Id == productId, x => x.Category, x => x.Store);
			var map = mapper.Map<ProductDto>(product);

			return map;
		}

		public async Task UpdateProductAsync(ProductUpdateDto productUpdateDto)
		{
			var product = await unitOfWork.GetRepository<Product>().GetAsync(x => !x.IsDeleted && x.Id == productUpdateDto.Id, x => x.Category, x => x.Store);

			product.ProductCode = productUpdateDto.ProductCode;
			product.ProductName = productUpdateDto.ProductName;
			product.Brand = productUpdateDto.Brand;
			product.Stock = productUpdateDto.Stock;
			product.CategoryId = productUpdateDto.CategoryId;
			product.StoreId = productUpdateDto.StoreId;


			await unitOfWork.GetRepository<Product>().UpdateAsync(product);
			await unitOfWork.SaveAsync();
		}

		public async Task SafeDeleteProductAsync(Guid productId)
		{
			var product = await unitOfWork.GetRepository<Product>().GetByGuidAsync(productId);

			product.IsDeleted = true;
			product.DeletedDate = DateTime.Now;

			await unitOfWork.GetRepository<Product>().UpdateAsync(product);
			await unitOfWork.SaveAsync();
		}
	}
}
