using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySolution.Domain.Entities;

namespace MySolution.Infrastructure.FluentApi
{
    public class CategoryFluent : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            // Other examples:
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar(100)");
        }
    }
}