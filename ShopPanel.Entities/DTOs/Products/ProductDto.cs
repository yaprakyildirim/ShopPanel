using ShopPanel.Entity.DTOs.Categories;
using ShopPanel.Entity.Entities;

namespace ShopPanel.Entity.DTOs.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public Store Store { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}