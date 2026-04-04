namespace __ServiceName__.Presentation.WebApi.Shared.HealthCheck.Models;

public sealed record ApplicationHealthProfile(bool LiveIsHealthy, bool ReadyIsHealthy);
