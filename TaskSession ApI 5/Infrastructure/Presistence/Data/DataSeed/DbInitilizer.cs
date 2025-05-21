using System.Text.Json;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Presistence.Data.DataSeed;

public class DbInitilizer : IDbInitilizer
{
    private readonly ApplicationDbContext _dbContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;

    public DbInitilizer(ApplicationDbContext dbContext,RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public async Task InitializeAsync()
    {
        try
        {
            if (!_dbContext.Database.GetPendingMigrations().Any())
            {
                await _dbContext.Database.MigrateAsync();
                if (!_dbContext.ProductTypes.Any())
                {
                    var productTypesJson= await File.ReadAllTextAsync("/mnt/Track/Courses/Route/Backend/C#Studying/API/api/Infrastructure/Presistence/Data/DataSeed/types.json");
                    var productTypes=JsonSerializer.Deserialize<List<ProductType>>(productTypesJson);
                    if (productTypes != null && productTypes.Any())
                    {
                        await _dbContext.ProductTypes.AddRangeAsync(productTypes);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var productBrandsJson= await File.ReadAllTextAsync("/mnt/Track/Courses/Route/Backend/C#Studying/API/api/Infrastructure/Presistence/Data/DataSeed/brands.json");
                    var productBrands=JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsJson);
                    if (productBrands != null && productBrands.Any())
                    {
                        await _dbContext.ProductBrands.AddRangeAsync(productBrands);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                if (!_dbContext.Products.Any())
                {
                    var productsJson= await File.ReadAllTextAsync("/mnt/Track/Courses/Route/Backend/C#Studying/API/api/Infrastructure/Presistence/Data/DataSeed/products.json");
                    var products=JsonSerializer.Deserialize<List<Product>>(productsJson);
                    if (products != null && products.Any())
                    {
                        await _dbContext.Products.AddRangeAsync(products);
                       await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    public async Task IdentityInitializeAsync()
    {
        if (!_roleManager.Roles.Any())
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        }

        if (!_userManager.Users.Any())
        {
            var adminUser = new User()
            {
                DisplayName = "Admin",
                UserName = "Admin",
                Email = "adel.erorr159@gmail.commm",
                PhoneNumber = "01894145154188454"
            };
            var superAdmin = new User()
            {
                DisplayName = "SuperAdmin",
                UserName = "SuperAdmin",
                Email = "adel@gmail.com",
                PhoneNumber = "018941455554188454"
            };
            await _userManager.CreateAsync(adminUser, "P@ssw0rd");
            await _userManager.CreateAsync(superAdmin, "P@ssw5rd");
            await _userManager.AddToRoleAsync(adminUser, "Admin");
            await _userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
        }
    }
}