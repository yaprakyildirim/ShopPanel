using ShopPanel.Core.Entities;

namespace ShopPanel.Entity.Entities
{
    public class Store : EntityBase
	{
		public Store()
		{

		}

		public Store(string storeName, string address, int phone, string createdBy)
		{
			storeName = StoreName;
			address = Address;
			phone = Phone;
			createdBy = CreatedBy;
		}
		public string StoreName { get; set; }
		public string Address { get; set; }
		public int Phone { get; set; }

		public ICollection<Product> Products { get; set; }
		public ICollection<AppUser> AppUsers { get; set; }
	}
}
