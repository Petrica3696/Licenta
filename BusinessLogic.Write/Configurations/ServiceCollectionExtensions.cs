using BusinessLogic.Write.Abstractions;
using BusinessLogic.Write.Implementations;
using DataAccess.Write.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Write.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString, string readUrl)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IProductLogic, ProductLogic>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
        }
    }
}
