using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configrations;

public class ProductConfigration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.Brand)
            .WithMany().HasForeignKey(p => p.BrandId);
        builder.HasOne(p => p.Type).WithMany().HasForeignKey(p => p.TypeId);
        builder.Property(p=>p.Price).HasColumnType("decimal(18,3)");
    }
}