using Datanaut.Models;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Tests.Utilities
{
    public static class InMemoryContextFactory
    {
        public static DatanautDbContext CreateContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<DatanautDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new DatanautDbContext(options);
        }
    }
}
