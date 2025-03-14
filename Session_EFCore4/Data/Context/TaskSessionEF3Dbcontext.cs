using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskSessionEFcore3.Data.DomainModels;

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
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.;Database=EFTaskSession3;User Id=sa;Password=syber@4backend;TrustServerCertificate=True");

        }
      
      //  public DbSet<Employee> Employee { get; set; } // shouldn't be in this class when i use Tpcc
       public DbSet<FullTimeEmployee>fullTimeEmployees { get; set; }
       public DbSet<PartTimeEmployee> partTimeEmployees { get; set; }
    
      //  public DbSet<Department> Departments { get; set; }
      
    }
    
}
