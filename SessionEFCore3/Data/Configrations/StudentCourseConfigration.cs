using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSessionEFcore3.Data.DomainModels;
namespace TaskSessionEFcore3.Data.Configrations;

public class StudentCourseConfigration:IEntityTypeConfiguration<Stud_Course>
{
    public void Configure(EntityTypeBuilder<Stud_Course> builder)
    {
        builder.HasKey(sc => new { sc.StudentId, sc.CourseId }); 
    }
}