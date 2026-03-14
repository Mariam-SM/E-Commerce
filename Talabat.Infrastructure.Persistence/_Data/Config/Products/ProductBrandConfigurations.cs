using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Talabat.Infrastructure.Persistence.Data.Config.Products
{
    public class ProductBrandConfigurations 
        : BaseAuditableEntityConfigurations<ProductBrand, int>
    {
        public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
