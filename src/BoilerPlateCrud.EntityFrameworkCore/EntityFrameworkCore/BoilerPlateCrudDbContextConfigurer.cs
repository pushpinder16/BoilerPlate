using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateCrud.EntityFrameworkCore
{
    public static class BoilerPlateCrudDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BoilerPlateCrudDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BoilerPlateCrudDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
