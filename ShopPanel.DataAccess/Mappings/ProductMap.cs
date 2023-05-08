using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopPanel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.DataAccess.Mappings
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(new Product
			{
				Id = Guid.NewGuid(),
				ProductCode = 1,
				ProductName = "Coko",
				Brand = "Ülker",
				Stock = 90,
				CategoryId = Guid.Parse("CF794B4B-DDF3-4DC4-9905-5AD6ADFB9CD5"),
				StoreId = Guid.Parse("C9CC4F4E-39EE-46C9-B5A6-FCB2674C71C8"),
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false,
				UserId = Guid.Parse("E6C8D1CD-1B18-473A-B68A-7B3CB247307D")
			},
				new Product
				{
					Id = Guid.NewGuid(),
					ProductCode = 2,
					ProductName = "Puskevit",
					Brand = "Torku",
					Stock = 80,
					CategoryId = Guid.Parse("19AA3E6C-B4AA-4E53-998B-DBF0A5750512"),
					StoreId = Guid.Parse("40888F2B-9891-4FA4-ABB2-993E4682FD0B"),
					CreatedBy = "Admin Test",
					CreatedDate = DateTime.Now,
					IsDeleted = false,
					UserId = Guid.Parse("4F3D95F2-AD3E-4172-9B35-3D80ECFD0624")
				}
			);
		}
	}
}
