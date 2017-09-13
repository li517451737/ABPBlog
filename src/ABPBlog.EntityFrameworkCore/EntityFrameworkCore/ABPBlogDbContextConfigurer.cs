using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ABPBlog.EntityFrameworkCore
{
    public static class ABPBlogDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ABPBlogDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ABPBlogDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}