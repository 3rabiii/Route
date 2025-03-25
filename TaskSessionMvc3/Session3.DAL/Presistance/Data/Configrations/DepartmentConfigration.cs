using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session3.DAL.Entities;

namespace Session3.DAL.Presistance.Data.Configrations;

public class DepartmentConfigration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(D => D.Id).UseIdentityColumn(10, 10);
        builder.Property(D => D.Name).HasMaxLength(100).IsRequired();
        builder.Property(D => D.Code).HasMaxLength(20).IsRequired();
        builder.Property(D => D.Description).HasMaxLength(500).IsRequired();
        builder.Property(D=>D.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        builder.Property(D=>D.CreateDateOn).HasDefaultValueSql("GETDATE()");
        
    }
}