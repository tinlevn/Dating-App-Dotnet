using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();

            services.AddDbContext<DataContext>(options =>
            {   
                //Colon to get into the next level of json {} wrapping connstring=>defaultconn
                options.UseSqlite(config["ConnectionStrings:DefaultConnection"]);
            });

            return services;
        }
    }
}