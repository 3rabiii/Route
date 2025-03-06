using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSessionEFcore3.Data.DomainModels;

namespace TaskSessionEFcore3.Data.Configrations
{

    public class InstructorConfigration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            // builder.HasOne(I => I.Department)
            //     .WithMany(D=>D.Instructors)
            //     .HasForeignKey(I=>I.DepartmentId)
            //     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}