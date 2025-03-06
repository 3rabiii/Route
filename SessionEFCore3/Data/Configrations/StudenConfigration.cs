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
    internal class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // builder.HasOne(E => E.Department)
            //     .WithMany(D => D.Students)
            //     .HasForeignKey(E => E.DepartmnetId)
            //     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}