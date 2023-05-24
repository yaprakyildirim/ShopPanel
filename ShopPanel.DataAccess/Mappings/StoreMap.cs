using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPanel.Entity.Entities;

namespace ShopPanel.DataAccess.Mappings
{
    public class StoreMap : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(new Store
            {
                Id = Guid.Parse("C9CC4F4E-39EE-46C9-B5A6-FCB2674C71C8"),
                StoreName = "Kartal",
                Address = "Kartal Atalar mah",
                Phone = 216145,
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Store
            {
                Id = Guid.Parse("40888F2B-9891-4FA4-ABB2-993E4682FD0B"),
                StoreName = "Pendik",
                Address = "Pendik Dogu mah",
                Phone = 316145,
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}