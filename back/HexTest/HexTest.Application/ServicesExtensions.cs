using Microsoft.Extensions.DependencyInjection;

namespace HexTest.Application;

public static class ServicesExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(ServicesExtensions));
        });

        return services;
    }
}