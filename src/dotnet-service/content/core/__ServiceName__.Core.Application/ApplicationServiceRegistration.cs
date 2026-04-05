using Microsoft.Extensions.DependencyInjection;

namespace __ServiceName__.Core.Application;

public static class ApplicationServiceRegistration
{
	extension(IServiceCollection services)
	{
		public IServiceCollection AddApplicationLayer()
		{
			return services;
		}
	}
}
