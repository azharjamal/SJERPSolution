
using SJERP.Domain.Interfaces;
using SJERP.Domain.Services;
using SJERP.Infrastructure.Context;
using SJERP.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SJERP.Business.Authentication.Services;

namespace SJERP.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<SJERPDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryService, InventoryService>();

            services.AddScoped<IInventoryDetailRepository, InventoryDetailRepository>();
            services.AddScoped<IInventoryDetailService, InventoryDetailService>();

            //services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<IBookService, BookService>();

            // configure DI for application services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
