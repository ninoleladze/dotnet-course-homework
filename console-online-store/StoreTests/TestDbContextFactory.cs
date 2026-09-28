namespace StoreTests;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Data.InitDataFactory;

/// <summary>
/// Builds a <see cref="StoreDbContext"/> backed by a fresh, isolated in-memory SQLite database
/// (unlike EF Core's InMemory provider, this enforces real foreign keys and cascade deletes) so
/// each test runs against its own database seeded with <see cref="TestDataFactory"/> data.
/// </summary>
internal static class TestDbContextFactory
{
    /// <summary>
    /// Creates a new context backed by a fresh in-memory SQLite database, seeded with test data.
    /// </summary>
    /// <returns>A ready-to-use, schema-created context.</returns>
    public static StoreDbContext Create()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder<StoreDbContext>().UseSqlite(connection).Options;
        var context = new StoreDbContext(options, new TestDataFactory());
        context.Database.EnsureCreated();
        return context;
    }
}
