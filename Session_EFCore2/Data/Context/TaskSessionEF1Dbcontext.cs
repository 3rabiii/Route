using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskSessionEFCore1.Data.Context
{
    public class TaskSessionEF1Dbcontext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ConfigrationWay
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion

            #region FluentApisWay
            modelBuilder.Entity<Student>(s =>
            {
                //s.HasKey(s => s.Id);
                //s.Property(s => s.Id)
                // .UseIdentityColumn(1, 1);
                //s.Property(s => s.FName)
                //  .IsRequired()
                //  .HasMaxLength(50);
                //s.Property(s => s.LName)
                //  .HasMaxLength(50)
                //  .IsRequired(false)
                //  .HasDefaultValue("LastName");
                //s.Property(s => s.Address)
                //  .HasMaxLength(50);
              

            });
            modelBuilder.Entity<Course>(c =>
            {
                //c.HasKey(c => c.Id);
                //c.Property(c => c.Id)
                // .UseIdentityColumn(1, 1);
                //c.Property(c => c.Name)
                // .HasMaxLength(50)
                // .IsRequired();
                //c.Property(c => c.Duration)
                // .IsRequired();
                });
            modelBuilder.Entity<Department>(d =>
            {
                //d.HasKey(d => d.Id);
                //d.Property(d => d.Id)
                // .UseIdentityColumn(10, 10);
                //d.Property(d=>d.Name)
                // .IsRequired()
                // .HasMaxLength(50);
                //d.Property(d => d.Hiring)
                // .IsRequired();
            });
            modelBuilder.Entity<Instructor>(i =>
            {
                //i.HasKey(i => i.Id);
                //i.Property(i => i.Id)
                // .UseIdentityColumn();
                //i.Property(i => i.Name)
                // .IsRequired()
                // .HasMaxLength(50);
                //i.Property(i => i.Address)
                //  .IsRequired();

            });
            modelBuilder.Entity<Topic>(t=>{
                //t.HasKey(t => t.Id);
                //t.Property(t => t.Id)
                //  .UseIdentityColumn();
                //t.Property(t => t.Name)
                // .IsRequired()
                // .HasMaxLength(50);
            });
            #endregion

        }
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
