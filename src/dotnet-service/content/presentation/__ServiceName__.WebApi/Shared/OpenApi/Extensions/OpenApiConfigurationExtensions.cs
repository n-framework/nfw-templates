using System;
using System.Threading.Tasks;
using __ServiceName__.Presentation.WebApi.Shared.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace __ServiceName__.Presentation.WebApi.Shared.OpenApi.Extensions;

public static class OpenApiConfigurationExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddOpenApiSupport(IConfiguration configuration)
        {
            var openApi = configuration.GetOpenApiConfiguration();

            _ = services.AddOpenApi(options =>
            {
                _ = options.AddDocumentTransformer(
                    (document, _, _) =>
                    {
                        document.Info = new()
                        {
                            Title = openApi.Title,
                            Version = openApi.Version,
                            Description = openApi.Description,
                            Contact = new() { Name = openApi.ContactName, Email = openApi.ContactEmail },
                            License = new() { Name = openApi.LicenseName, Url = new Uri(openApi.LicenseUrl) },
                        };
                        return Task.CompletedTask;
                    }
                );
            });

            return services;
        }
    }

    extension(IConfiguration configuration)
    {
        public OpenApiConfiguration GetOpenApiConfiguration()
        {
            var section = configuration.GetSection("OpenApi");
            var openApi = section.Get<OpenApiConfiguration>();
            if (openApi is null)
            {
                throw new InvalidOperationException("OpenApi configuration is not found.");
            }

            return openApi;
        }
    }

    extension(IApplicationBuilder app)
    {
        public IApplicationBuilder UseOpenApiUi()
        {
            _ = app.UseRouting();
            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapOpenApi();
            });

            return app;
        }
    }
}
