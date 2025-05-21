using E_Commerse.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerse.Extentions;

public static class PresentationServicesExtention
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection Services)
    {
        Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemplyReference).Assembly);
        Services.AddEndpointsApiExplorer();
        Services.AddSwaggerGen();
        Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomeValidationErorrResponse;
        });
        return Services;
    }
}