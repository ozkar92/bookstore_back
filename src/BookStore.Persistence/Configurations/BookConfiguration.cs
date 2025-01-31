using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Author).HasMaxLength(100);
            builder.Property(x => x.ISBN).HasMaxLength(100);
            builder.HasIndex(x => x.Title);
            
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasQueryFilter(x => x.Status);
        }
    }
}
