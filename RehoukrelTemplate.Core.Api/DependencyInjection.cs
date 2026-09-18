using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RehoukrelTemplate.Core.Api.Setups;

namespace RehoukrelTemplate.Core.Api;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddServiceSetups<TDbContext>(
        this IHostApplicationBuilder builder, 
        IConfiguration configuration)
        where TDbContext : DbContext
    {
        builder
            .RegisterDatabase<TDbContext>("Postgres")
            .RegisterMessaging()
            .RegisterOpenApi();
        
        return builder;
    }
    
    public static WebApplication UseServiceSetups(this WebApplication app)
    {
        app
            .UseHttpsRedirection();
        
        app.RegisterScalar();
        
        return app;
    }
}