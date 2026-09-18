using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RehoukrelTemplate.Core.Api.Setups;

public static class MessagingSetup
{
    public static IServiceCollection RegisterMessaging(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        
        return services;
    }
}