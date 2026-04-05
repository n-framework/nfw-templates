using __ServiceName__.Core.Application;
using __ServiceName__.Infrastructure.Persistence;
using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Extensions;
using __ServiceName__.Presentation.WebApi.Shared.OpenApi.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureServices(builder.Configuration.GetInfrastructureConfiguration());
builder.Services.AddHttpContextAccessor();
builder.Services.AddOpenApiSupport(builder.Configuration);
builder.Services.AddApplicationHealthChecks();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
	_ = app.UseOpenApiUi();
}

app.MapHealthCheckEndpoints();

app.Run();
