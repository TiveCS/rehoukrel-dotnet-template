using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RehoukrelTemplate.Core.Infra.Data.EFCore.Interceptors;

namespace RehoukrelTemplate.Core.Api.Setups;

public static class DbSetup
{
    public static IServiceCollection RegisterDatabase<TDbContext>(
        this IHostApplicationBuilder builder, 
        string connectionName)
        where TDbContext : DbContext
    {
        builder.AddNpgsqlDbContext<TDbContext>(connectionName, configureDbContextOptions: opt =>
        {
            opt.AddInterceptors(new AuditInterceptor());
        });
            
        return builder.Services;
    }
}