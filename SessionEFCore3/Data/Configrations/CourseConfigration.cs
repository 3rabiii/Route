using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSessionEFcore3.Data.DomainModels;
using TaskSessionEFCore3.Data.DomainModels;

namespace TaskSessionEFCore3.Data.Configrations
{
    internal class CourseConfigration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // builder.HasOne(C=>C.Topic)
            //     .WithMany(T=>T.Courses)
            //     .HasForeignKey(C=>C.TopicId)
            //     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}