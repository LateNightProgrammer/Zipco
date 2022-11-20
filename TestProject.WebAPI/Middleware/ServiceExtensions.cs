using System.Runtime.CompilerServices;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Repository;
using TestProject.WebAPI.Services;

namespace TestProject.WebAPI.Middleware
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) 
            => services.AddScoped<Contracts.ILogManager, LogManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<ZipcoContext>
            (opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("TestProject.WebAPI")));

        //public static void ConfigureSqlContext(this IServiceCollection services,
        //    IConfiguration configuration) => services.AddDbContext<ZipcoContext>
        //(opts =>
        //    opts.UseInMemoryDatabase("sqlConnection"));

        public static void ConfigureRepositoryManager(this IServiceCollection services) 
            => services.AddScoped<IRepositoryManager, RepositoryManager>();


        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ZipCo Test API",
                    Version = "v1"
                })
            );
        }
    }
}
