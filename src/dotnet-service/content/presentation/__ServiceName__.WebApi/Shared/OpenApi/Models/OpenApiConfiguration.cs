namespace __ServiceName__.Presentation.WebApi.Shared.OpenApi.Models;

public sealed record OpenApiConfiguration(
    string Title,
    string Version,
    string Description,
    string ContactName,
    string ContactEmail,
    string LicenseName,
    string LicenseUrl
);
