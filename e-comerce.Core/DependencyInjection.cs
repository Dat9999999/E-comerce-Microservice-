using e_comerce.Infrastructure.ServiceContracts;
using e_comerce.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace e_comerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
        
    }
}