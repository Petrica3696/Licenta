using BusinessLogic.Read.Abstractions.Logics;
using BusinessLogic.Read.Abstractions.QueryBuilders;
using BusinessLogic.Read.Implementations.Logics;
using BusinessLogic.Read.Implementations.QueryBuilders;
using DataAccess.Read.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<IUserQueryBuilder, UserQueryBuilder>();
            services.AddScoped<IUserLogic, UserLogic>();

            services.AddScoped<IProductQueryBuilder, ProductQueryBuilder>();
            services.AddScoped<IProductLogic, ProductLogic>();

            services.AddScoped<ICategoryQueryBuilder, CategoryQueryBuilder>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
        }
    }
}
