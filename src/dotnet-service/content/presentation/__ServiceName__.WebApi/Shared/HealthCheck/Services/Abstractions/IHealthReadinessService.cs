using __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Models;

namespace __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Services.Abstractions;

public interface IHealthReadinessService
{
    HealthStatus GetLiveStatus();
    HealthStatus GetReadyStatus();
}
