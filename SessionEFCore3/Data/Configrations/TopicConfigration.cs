using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSessionEFCore3.Data.DomainModels;

namespace TaskSessionEFCore3.Data.Configrations
{
    internal class TopicConfigration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            // builder.HasMany(T=>T.Courses)
            //     .WithOne(C=>C.Topic)
            //     .HasForeignKey(C=>C.TopicId)
            //     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}