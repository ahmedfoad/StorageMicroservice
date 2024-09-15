using Microsoft.Extensions.DependencyInjection;
using StorageMicroservice.Application.Services;

namespace StorageMicroservice.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();
        return services;
    }
}
