using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;
using MultiShop.Cargo.DataAccessLayer.Repositories;

namespace MultiShop.Cargo.WebAPI.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCargoServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = configuration["IdentityServerUrl"];
                opt.Audience = "ResourceCargo";
                opt.RequireHttpsMetadata = false;
            });

            // Add services to the container.
            services.AddDbContext<CargoContext>();
            
            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
            services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            
            services.AddScoped<ICargoDetailService, CargoDetailManager>();
            services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            
            services.AddScoped<ICargoOperationService, CargoOperationManager>();
            services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
            
            services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
