using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskSessionEFCore1.Data.Configrations
{
    internal class TopicConigration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
              .UseIdentityColumn();
            builder.Property(t => t.Name)
             .IsRequired()
             .HasMaxLength(50);
        }
    }
}
