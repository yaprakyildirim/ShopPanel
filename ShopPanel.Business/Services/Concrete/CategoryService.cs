using AutoMapper;
using ShopPanel.Business.Services.Abstract;
using ShopPanel.DataAccess.UnitOfWorks;
using ShopPanel.Entity.DTOs.Categories;
using ShopPanel.Entity.Entities;

namespace ShopPanel.Business.Services.Concrete
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
		public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
		{
			var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
			var map = mapper.Map<List<CategoryDto>>(categories);

			return map;
		}
	}
}
