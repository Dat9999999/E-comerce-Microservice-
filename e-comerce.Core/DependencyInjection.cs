using Microsoft.Extensions.DependencyInjection;

namespace e_comerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
        
    }
}