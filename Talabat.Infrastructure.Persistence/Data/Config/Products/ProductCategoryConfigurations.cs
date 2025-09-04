using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Talabat.Infrastructure.Persistence.Data.Config.Products
{
    public class ProductCategoryConfigurations 
        : BaseAuditableEntityConfigurations<ProductCategory, int>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);
            builder.Property(cat => cat.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
