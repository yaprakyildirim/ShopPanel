using Microsoft.AspNetCore.Identity;

namespace ShopPanel.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Guid StoreId { get; set; }
		public Store Store { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
