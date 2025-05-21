using System.Text;
using Domain.Contracts;
using Domain.Entities;
using E_Commerse.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presistence.Data;
using Presistence.Data.DataSeed;
using Presistence.Repository;
using Shared;
using StackExchange.Redis;

namespace E_Commerse.Extentions;

public static class InfrastructureServicesExtention
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services, IConfiguration Configuration)
    {
        Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });
        Services.AddDbContext<IdentityApplicationDbcontext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
        });
        Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = true; 
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireDigit = true;
            options.User.RequireUniqueEmail= true;
        }).AddEntityFrameworkStores<IdentityApplicationDbcontext>();
        Services.AddScoped<IDbInitilizer,DbInitilizer>();
        Services.AddScoped<IUnitOfWork, UnitOfWork>();
        Services.AddSingleton<IConnectionMultiplexer>(options=> ConnectionMultiplexer.Connect(Configuration.GetConnectionString("Redis")!));
        Services.AddScoped<IBasketRepository, BasketRepository>();
        Services.ConfigureJwt(Configuration);
        return Services;
    }

    public static IServiceCollection ConfigureJwt(this IServiceCollection Services, IConfiguration Configuration)
    {
        var JwtOptions=Configuration.GetSection("JwtOptions").Get<JwtOptions>();
        Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(Options =>
        {
            Options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = JwtOptions.issuer,
                ValidAudience = JwtOptions.audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.secretKey))
            };
        });
        Services.AddAuthorization();
        return Services;
    }
}