using Domain.Contracts;
using E_Commerse.Extentions;
using E_Commerse.Factories;
using E_Commerse.Midellwares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Presistence.Data.DataSeed;
using Presistence.Repository;
using Services;
using ServicesAbstraction;

namespace E_Commerse;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Services
        // Presentation Services
        builder.Services.AddPresentationServices();
        //Infrastructure Services
        builder.Services.AddInfrastructureServices(builder.Configuration);
        //Core Services
        builder.Services.AddCoreServices(builder.Configuration);
        
        var app = builder.Build();
        #endregion

        #region Piplines/Midellwares

        app.CustomeMiddleware();
        await app.SeedDbInitializeAsync();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

        #endregion
        
    }
}