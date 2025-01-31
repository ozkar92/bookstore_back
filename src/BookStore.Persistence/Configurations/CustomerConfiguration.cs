using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.LastName).HasMaxLength(250);
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasQueryFilter(x => x.Status);
        }
    }
}
