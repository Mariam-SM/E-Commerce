using Talabat.Domain.Identity;
using Talabat.Infrastructure.Persistence.Common;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.Infrastructure.Persistence.Identity.Config
{
    [DbContextType(typeof(StoreIdentityDbContext))]

    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.Property(a => a.FirstName).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(a => a.LastName).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(a => a.Street).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(a => a.City).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(a => a.Country).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
