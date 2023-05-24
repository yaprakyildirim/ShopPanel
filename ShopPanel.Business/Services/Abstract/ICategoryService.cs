using ShopPanel.Entity.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Business.Services.Abstract
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
    }
}
