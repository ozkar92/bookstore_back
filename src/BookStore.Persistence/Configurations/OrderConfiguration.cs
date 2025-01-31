using System;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.Property(x => x.OrderDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
            builder.HasMany(x => x.Books).WithMany(x => x.Orders);
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasQueryFilter(x => x.Status);
        }
    }
}
