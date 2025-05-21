using Services;
using ServicesAbstraction;
using Shared;

namespace E_Commerse.Extentions;

public static class CoreServicesExtention
{
    public static IServiceCollection AddCoreServices(this IServiceCollection Services,IConfiguration configuration)
    {
        Services.AddScoped<IServiceMangger,ServiceMangger>();
        Services.AddAutoMapper(typeof(Services.AssemplyReference).Assembly); // pass dll and this class not make anything just i take dll from it using assemply
        Services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        return Services;
    }
}