using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Services.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Endpoints;

public static class HealthEndpointsExtensions
{
    extension(IEndpointRouteBuilder endpoints)
    {
        public void MapHealthEndpoints()
        {
            _ = endpoints.MapGet(
                "/health/live",
                (IHealthReadinessService healthService) =>
                {
                    var status = healthService.GetLiveStatus();
                    return Results.Ok(
                        new
                        {
                            status = status.Name,
                            healthy = status.IsHealthy,
                            checkedAtUtc = status.CheckedAtUtc,
                        }
                    );
                }
            );

            _ = endpoints.MapGet(
                "/health/ready",
                (IHealthReadinessService healthService) =>
                {
                    var status = healthService.GetReadyStatus();
                    return Results.Ok(
                        new
                        {
                            status = status.Name,
                            healthy = status.IsHealthy,
                            checkedAtUtc = status.CheckedAtUtc,
                        }
                    );
                }
            );
        }
    }
}
