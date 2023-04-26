using ShopPanel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Entity.Entities
{
	public class Category : EntityBase	
	{
		public Category()
		{

		}

		public Category(string name, string createdBy)
		{
			Name = name;
			CreatedBy = createdBy;
		}
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
