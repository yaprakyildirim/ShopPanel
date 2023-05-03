using ShopPanel.Entity.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Business.Services.Abstract
{
	public interface IProductService
	{
		Task<List<ProductDto>> GetAllProductsWithCategoryNonDeletedAsync();
		Task<ProductDto> GetProductWithCategoryNonDeletedAsync(Guid productId);
		Task CreateProductAsync(ProductAddDto productAddDto);
		Task UpdateProductAsync(ProductUpdateDto productUpdateDto);
		Task SafeDeleteProductAsync(Guid productId);
	}
}
