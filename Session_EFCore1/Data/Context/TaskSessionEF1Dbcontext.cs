using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskSessionEFCore1.Data.Context
{
    public class TaskSessionEF1Dbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFSession1;Trusted_Connection=True;TrustServerCertificate=True");

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Course_Inst> course_Insts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Stud_Course> Stud_Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
    
}
