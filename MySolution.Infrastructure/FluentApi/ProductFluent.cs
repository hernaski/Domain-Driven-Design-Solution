using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySolution.Domain.Entities;

namespace MySolution.Infrastructure.FluentApi
{
    public class ProductFluent : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.HasOne(e => e.Category);

            // Other examples:

            //builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar(150)");
            //builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar(500)");
        }
    }
}