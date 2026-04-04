using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Models;
using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Services.Abstractions;

namespace __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Services;

public sealed class DefaultHealthReadinessService(ApplicationHealthProfile profile) : IHealthReadinessService
{
    public HealthStatus GetLiveStatus() => new("live", profile.LiveIsHealthy, DateTimeOffset.UtcNow);

    public HealthStatus GetReadyStatus() => new("ready", profile.ReadyIsHealthy, DateTimeOffset.UtcNow);
}
