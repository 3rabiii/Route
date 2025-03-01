using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskSessionEFCore1.Data.Configrations
{
    internal class InstructorConfigration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
             .UseIdentityColumn();
            builder.Property(i => i.Name)
             .IsRequired()
             .HasMaxLength(50);
            builder.Property(i => i.Address)
              .IsRequired();
        }
    }
}
