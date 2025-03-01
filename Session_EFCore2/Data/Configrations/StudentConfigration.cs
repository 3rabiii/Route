using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskSessionEFCore1.Data.Configrations
{
    internal class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
             .UseIdentityColumn(1, 1);
            builder.Property(s => s.FName)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(s => s.LName)
              .HasMaxLength(50)
              .IsRequired(false)
              .HasDefaultValue("LastName");
            builder.Property(s => s.Address)
              .HasMaxLength(50);
        }
    }
}
