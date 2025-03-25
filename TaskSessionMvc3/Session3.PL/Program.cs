using Microsoft.EntityFrameworkCore;
using Session3.DAL.Presistance.Data;

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
        var app = builder.Build();
        app.Run();
    }
}