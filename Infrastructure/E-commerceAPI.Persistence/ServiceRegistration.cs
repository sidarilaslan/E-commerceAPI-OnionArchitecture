    using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Repositories.BasketItemRepository;
using E_commerceAPI.Application.Repositories.BasketRepository;
using E_commerceAPI.Application.Repositories.BrandRepository;
using E_commerceAPI.Application.Repositories.CategoryRepository;
using E_commerceAPI.Application.Repositories.CompletedOrderRepository;
using E_commerceAPI.Application.Repositories.EndpointRepository;
using E_commerceAPI.Application.Repositories.FileRepository;
using E_commerceAPI.Application.Repositories.MenuRepository;
using E_commerceAPI.Application.Repositories.OrderRepository;
using E_commerceAPI.Application.Repositories.ProductImageFileRepository;
using E_commerceAPI.Application.Repositories.ProductRepository;
using E_commerceAPI.Application.Repositories.UserRepository;
using E_commerceAPI.Domain.Entities.Identity;
using E_commerceAPI.Persistence.Contexts;
using E_commerceAPI.Persistence.Contexts.EntityFramework;
using E_commerceAPI.Persistence.Repositories.BasketItemRepository;
using E_commerceAPI.Persistence.Repositories.BasketRepository;
using E_commerceAPI.Persistence.Repositories.BrandRepository;
using E_commerceAPI.Persistence.Repositories.CategoryRepository;
using E_commerceAPI.Persistence.Repositories.CompletedOrderRepository;
using E_commerceAPI.Persistence.Repositories.EndpointRepository;
using E_commerceAPI.Persistence.Repositories.FileRepository;
using E_commerceAPI.Persistence.Repositories.MenuRepository;
using E_commerceAPI.Persistence.Repositories.OrderRepository;
using E_commerceAPI.Persistence.Repositories.ProductImageFileRepository;
using E_commerceAPI.Persistence.Repositories.ProductRepository;
using E_commerceAPI.Persistence.Repositories.UserRepository;
using E_commerceAPI.Persistence.Services;
using E_E_commerceAPI.Application.Abstractions.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(ConnectionStringConfiguration.GetLocalMssqlServerConnectionString()));

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1);
            });
            services.AddIdentity<AppUser, AppRole>(options => options.User.RequireUniqueEmail = true)
                .AddDefaultTokenProviders()
              .AddEntityFrameworkStores<ECommerceDbContext>();

            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
            services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();

            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();

            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();

            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();




        }
    }

}
