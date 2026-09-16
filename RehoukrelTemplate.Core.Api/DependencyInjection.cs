using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RehoukrelTemplate.Core.Api.Setups;

namespace RehoukrelTemplate.Core.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceSetups<TDbContext>(
        this IServiceCollection services, 
        IConfiguration configuration)
        where TDbContext : DbContext
    {
        services
            .RegisterDatabase<TDbContext>()
            .RegisterCqrs()
            .RegisterOpenApi();
        
        return services;
    }
    
    public static WebApplication UseServiceSetups(this WebApplication app)
    {
        app
            .UseHttpsRedirection();
        
        app.RegisterScalar();
        
        return app;
    }
}