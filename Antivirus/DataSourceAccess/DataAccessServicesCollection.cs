using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataSourceAccess
{
    public static class DataAccessServicesCollection
    {
        public static IServiceCollection AddDataAccessServiceCollection(this IServiceCollection services)
        {

            services.AddDbContext<AntivirusContext>(options => { options.UseInMemoryDatabase("localDb"); })
                .AddScoped<ISignatureRepository, SignatureRepository>()
                .AddScoped<IVirusRepository, VirusRepository>();
            
            return services;
        }
    }
}