using Domain.Contracts;
using E_Commerse.Midellwares;

namespace E_Commerse.Extentions;

public static class WebApplicationExtetions
{
    public async static Task<WebApplication> SeedDbInitializeAsync(this WebApplication app)
    {
        using var scop=app.Services.CreateScope();
        var dbInitializer = scop.ServiceProvider.GetRequiredService<IDbInitilizer>();
        await dbInitializer.InitializeAsync();
        await dbInitializer.IdentityInitializeAsync();
        return app;
    }
    public static WebApplication CustomeMiddleware(this WebApplication app)
    {
        app.UseMiddleware<GlobalErrorHandlingMidellware>();
        return app;
    }
}