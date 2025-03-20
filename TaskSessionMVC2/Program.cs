namespace Session2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        var app = builder.Build();
        
 
        //app.MapGet("/adel", () => "Hello World!");
        app.MapControllerRoute(
            name: "default",
            pattern:"{controller}/{action=Index}/{id:int?}");

        app.Run();
    }
}