using __ServiceName__.Infrastructure.Persistence.Shared.Database.Contexts;
using __ServiceName__.Infrastructure.Persistence.Shared.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace __ServiceName__.Infrastructure.Persistence;

public readonly record struct InfrastructureConfiguration(DatabaseConfiguration Database);

public static class InfrastructurePersistenceRegistrationExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructureServices(InfrastructureConfiguration configuration)
        {
            _ = services.AddDatabase(configuration);
            return services;
        }

        private IServiceCollection addDatabase(InfrastructureConfiguration configuration)
        {
            _ = services.AddDbContext<BaseDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: configuration.Database.Name)
            );

            return services;
        }
    }

    extension(IConfiguration configuration)
    {
        public InfrastructureConfiguration GetInfrastructureConfiguration()
        {
            DatabaseConfiguration database = configuration.GetDatabaseConfiguration();
            return new InfrastructureConfiguration(database);
        }

        public DatabaseConfiguration GetDatabaseConfiguration()
        {
            var section = configuration.GetSection("Database");
            string name = section.GetValue<string>("Name");
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidOperationException("Database:Name cannot be empty.");
            }

            return new DatabaseConfiguration(name.Trim());
        }
    }
}
