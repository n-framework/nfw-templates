using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace __ServiceName__.Core.Application;

public static class ApplicationServiceRegistration
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplicationLayer(IConfiguration configuration)
        {
            return services.AddApplicationServices();
        }

        public IServiceCollection AddApplicationServices()
        {
            return services;
        }
    }
}
