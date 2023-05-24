using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPanel.Entity.Entities;

namespace ShopPanel.DataAccess.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");


            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("E6C8D1CD-1B18-473A-B68A-7B3CB247307D"),
                RoleId = Guid.Parse("A780B1C8-6D4B-452D-9BC4-40F184964380")

            },
            new AppUserRole
            {
                UserId = Guid.Parse("4F3D95F2-AD3E-4172-9B35-3D80ECFD0624"),
                RoleId = Guid.Parse("C457729B-87E5-4D96-9965-EEFB8E36A203")
            });
        }
    }
}
