using __ServiceName__.Core.Application;
using __ServiceName__.Infrastructure.Persistence;
using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Endpoints;
using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Models;
using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Services;
using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Services.Abstractions;
using __ServiceName__.Presentation.WebApi.Shared.OpenApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration.GetInfrastructureConfiguration());
builder.Services.AddHttpContextAccessor();
builder.Services.AddOpenApiSupport(builder.Configuration);
builder.Services.AddSingleton(new ApplicationHealthProfile(LiveIsHealthy: true, ReadyIsHealthy: true));
builder.Services.AddScoped<IHealthReadinessService, DefaultHealthReadinessService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseOpenApiUi();
}

app.MapHealthEndpoints();

app.Run();
