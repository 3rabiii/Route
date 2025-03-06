using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSessionEFcore3.Data.DomainModels;

namespace TaskSessionEFcore3.Data.Configrations
{
    internal class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // builder.HasMany(D =>D.Students)
            //     .WithOne(E => E.Department)
            //     .HasForeignKey(E => E.DepartmentId)
            //     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}