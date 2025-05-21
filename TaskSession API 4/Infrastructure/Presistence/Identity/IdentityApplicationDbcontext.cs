using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerse.Identity;

public class IdentityApplicationDbcontext: IdentityDbContext
{
    public IdentityApplicationDbcontext(DbContextOptions<IdentityApplicationDbcontext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Address>().ToTable("Addresses");
    }
}