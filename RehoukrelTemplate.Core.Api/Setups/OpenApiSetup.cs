using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scalar.AspNetCore;

namespace RehoukrelTemplate.Core.Api.Setups;

public static class OpenApiSetup
{
    public static IServiceCollection SetupOpenApi(this IServiceCollection services)
    {
        services.AddOpenApi();
        return services;
    }

    public static WebApplication SetupScalar(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapScalarApiReference();
        }
        
        return app;
    }
}