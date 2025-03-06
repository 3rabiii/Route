using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSessionEFcore3.Data.DomainModels;
namespace TaskSessionEFcore3.Data.Configrations;

public class InstructorCourseConfigration:IEntityTypeConfiguration<Course_Inst>
{
    public void Configure(EntityTypeBuilder<Course_Inst> builder)
    {
        builder.HasKey(CI => new{CI.CourseId,CI.InstructorId }); 
    }
}