using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RehoukrelTemplate.Core.Api.Setups;

public static class DbSetup
{
    public static IServiceCollection SetupDatabase<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddDbContext<TDbContext>();
        return services;
    }
}