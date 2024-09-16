using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorageMicroservice.Infrastructure.Data;
using StorageMicroservice.Infrastructure.Repositories;

namespace StorageMicroservice.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StorageDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IFileRepository, FileRepository>();
        return services;
    }
}
