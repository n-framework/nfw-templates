# **ServiceName**

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

- `core/__ServiceName__.Domain`: Business entities and value objects.
- `core/__ServiceName__.Application`: Application services and DI registration helpers.
- `infrastructure/__ServiceName__.Persistence`: Database context (`BaseDbContext`), EF Core setup, and configuration models (e.g., `DatabaseConfiguration`).
- `presentation/__ServiceName__.WebApi`: Host bootstrap (`Program.cs`), health endpoints, and OpenAPI configuration.

## Health Endpoints

- `GET /health/live`
- `GET /health/ready`

---

```text
   _  ______                                   __
  / |/ / __/______ ___ _  ___ _    _____  ____/ /__
 /    / _// __/ _ `/  ' \/ -_) |/|/ / _ \/ __/  '_/
/_/|_/_/ /_/  \_,_/_/_/_/\__/|__,__/\___/_/ /_/\_\
```

Generated from template [`dotnet-service`](https://github.com/n-framework/nfw-templates).
