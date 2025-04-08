using Microsoft.EntityFrameworkCore;
using Session3.DAL.Presistance.Data;
using Session3.DAL.Presistance.Repostories.Departments;

namespace Session3.PL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ApplicationDbcontext>((options) =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

        });
        builder.Services.AddScoped<IDepartmentRepostory,DepartmentRepostory>();
        var app = builder.Build();
        app.Run();
    }
}