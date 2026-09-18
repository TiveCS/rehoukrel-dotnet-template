using Microsoft.EntityFrameworkCore;
using RehoukrelTemplate.Core.Infra.Data.EFCore.Extensions;

namespace RehoukrelTemplate.Identity.Infra.Data;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> opt) : DbContext(opt)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
        modelBuilder.ApplyCoreConfiguration();
        
        base.OnModelCreating(modelBuilder);
    }
}