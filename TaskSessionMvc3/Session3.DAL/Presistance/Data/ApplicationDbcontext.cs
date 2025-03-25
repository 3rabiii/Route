using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Session3.DAL.Entities;

namespace Session3.DAL.Presistance.Data;

public class ApplicationDbcontext: DbContext
{
    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Department>  Departments { get; set; }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("Server=.;Database=MVCSession3;Trusted_Connection=True;TrustServerCertificate=True;");
    // }
}