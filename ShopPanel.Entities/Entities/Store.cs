﻿using ShopPanel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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