using Antivirus.Scanner.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Antivirus.Scanner
{
    public static class InternalServicesExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IScannerService, ScannerService>();
            return services;
        }
    }
}