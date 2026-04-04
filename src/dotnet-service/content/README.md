# **ServiceName**

Generated from template `dotnet-service`.

## Folder Layout

```text
core/
  __ServiceName__.Domain/
  __ServiceName__.Application/
infrastructure/
  __ServiceName__.Persistence/
presentation/
  __ServiceName__.WebApi/
```

Each folder holds the clean architecture layers with corresponding `*.csproj` files.

Models (configuration, DTO, and helper records) live under `Models` subfolders inside each layer.

## Layer Highlights

- `core/__ServiceName__.Domain`: Business entities stored under `Shared/Entities` (e.g., `HealthStatus`).
- `core/__ServiceName__.Application`: Contracts, health-profile registration, and DI helpers.
- `core/__ServiceName__.Application`: Contracts live under `__ServiceName__.Application/Shared/Services/Abstractions`, shared models (e.g., `Shared/Models/ApplicationHealthProfile`), health-profile registration, and DI helpers.
- `infrastructure/__ServiceName__.Persistence`: DbContext, EF Core setup, and provider implementations (health readiness, configuration models).
- `presentation/__ServiceName__.WebApi`: Host bootstrap (`Program.cs`), OpenAPI wiring, configuration extensions, and launch settings.

## Health Endpoints

- `GET /health/live`
- `GET /health/ready`
