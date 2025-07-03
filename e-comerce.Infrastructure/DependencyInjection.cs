using e_comerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace e_comerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
        
    }
}