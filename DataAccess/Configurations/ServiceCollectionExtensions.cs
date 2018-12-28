using DataAccess.Read.Abstractions;
using DataAccess.Read.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Read.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IRepository, Repository>(serviceProvider => new Repository(connectionString));
            //services.AddScoped<IRoleRepository, RoleRepository>(serviceProvider => new RoleRepository(connectionString));
        }
    }
}
