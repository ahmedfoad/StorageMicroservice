using Microsoft.Extensions.DependencyInjection;
using StorageMicroservice.Infrastructure.Repositories;

namespace StorageMicroservice.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IFileRepository, FileRepository>();
        return services;
    }
}
