namespace __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Models;

public sealed record HealthStatus(string Name, bool IsHealthy, DateTimeOffset CheckedAtUtc);
