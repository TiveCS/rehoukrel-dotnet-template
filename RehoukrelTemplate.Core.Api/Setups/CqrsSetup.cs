using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RehoukrelTemplate.Core.Api.Setups;

public static class CqrsSetup
{
    public static IServiceCollection RegisterCqrs(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        
        return services;
    }
}