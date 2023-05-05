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
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(new Category
			{
				Id = Guid.Parse("CF794B4B-DDF3-4DC4-9905-5AD6ADFB9CD5"),
				Name = "Çikolata",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			},
			new Category
			{
				Id = Guid.Parse("19AA3E6C-B4AA-4E53-998B-DBF0A5750512"),
				Name = "Gofret",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			});
		}
	}
}