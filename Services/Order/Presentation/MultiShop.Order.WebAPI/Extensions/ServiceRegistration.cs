using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

namespace MultiShop.Order.WebAPI.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services, IConfiguration configuration)
        {
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            //{
            //    opt.Authority = builder.Configuration["IdentityServerUrl"];
            //    opt.Audience = "ResourceOrder";
            //    opt.RequireHttpsMetadata = false;
            //});

            // Add services to the container.
            services.AddDbContext<OrderContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IOrderingRepository), typeof(OrderingRepository));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));

            return services;
        }
    }
}
