using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Identity;
using Talabat.Infrastructure.Persistence.Common;

namespace Talabat.Infrastructure.Persistence.Identity.Config
{
    [DbContextType(typeof(StoreIdentityDbContext))]
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            
            builder.Property(u => u.DisplayName)
                     .HasColumnType("nvarchar")
                     .HasMaxLength(100)
                     .IsRequired();

            builder.HasOne(u => u.Address)
                   .WithOne(A=> A.User)
                   .HasForeignKey<Address>(a => a.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
