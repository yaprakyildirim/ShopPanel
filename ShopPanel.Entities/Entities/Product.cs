using ShopPanel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ShopPanel.Entity.Entities
{
	public class Product : EntityBase
	{
		public Product()
		{

		}

		public Product(int productCode, string productName, string brand, int stock, string createdBy, Guid categoryId, Guid storeId)
		{
			ProductCode = productCode;
			ProductName = productName;
			Brand = brand;
			Stock = stock;
			CategoryId = categoryId;
			StoreId = storeId;
			CreatedBy = createdBy;
		}
		public int ProductCode { get; set; }
		public string ProductName { get; set; }
		public string Brand { get; set; }
		public int Stock { get; set; }


		public Guid CategoryId { get; set; }
		public Category Category { get; set; }

		public Guid? StoreId { get; set; }
		public Store Store { get; set; }

		public Guid UserId { get; set; }
		public Guid User { get; set; }
	}
}
