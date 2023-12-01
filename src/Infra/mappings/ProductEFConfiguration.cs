using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CommandInterceptionWebApplication.Domain.Entitys;

namespace CommandInterceptionWebApplication.Infra.Mappings
{
    public class ProductEFConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", schema: "dbo");

            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.ProductTitle).IsRequired().HasMaxLength(150);
            builder.Property(p => p.ProductDescription).HasMaxLength(1500);
            builder.Property(p => p.MainImageName).HasMaxLength(1500);
            builder.Property(p => p.MainImageTitle).HasMaxLength(1500);
            builder.Property(p => p.MainImageUri).HasMaxLength(1500);
            builder.Property(p => p.IsFreeDelivery).IsRequired();
            builder.Property(p => p.IsExisting).IsRequired();
        }
    }
}
