using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskSessionEFCore1.Data.Configrations
{
    internal class CourseConigration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
             .UseIdentityColumn(1, 1);
            builder.Property(c => c.Name)
             .HasMaxLength(50)
             .IsRequired();
            builder.Property(c => c.Duration)
             .IsRequired();
        }
    }
}
