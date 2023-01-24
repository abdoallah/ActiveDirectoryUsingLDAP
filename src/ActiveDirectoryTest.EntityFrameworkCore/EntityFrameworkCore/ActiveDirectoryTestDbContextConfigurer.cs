using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ActiveDirectoryTest.EntityFrameworkCore
{
    public static class ActiveDirectoryTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ActiveDirectoryTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ActiveDirectoryTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
