using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskSessionEFcore3.Data.DomainModels;
using TaskSessionEFCore3.Data.DomainModels;

namespace TaskSessionEFcore3.Data.Context
{
    public class TaskSessionEF3Dbcontext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFTaskSession3;User Id=sa;Password=syber@4backend;TrustServerCertificate=True");

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
