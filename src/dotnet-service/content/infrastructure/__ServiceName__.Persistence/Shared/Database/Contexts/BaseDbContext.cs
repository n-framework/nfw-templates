using Microsoft.EntityFrameworkCore;

namespace __ServiceName__.Infrastructure.Persistence.Shared.Database.Contexts;

public sealed class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options);
