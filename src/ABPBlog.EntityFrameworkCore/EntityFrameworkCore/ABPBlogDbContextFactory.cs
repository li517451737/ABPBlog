using ABPBlog.Configuration;
using ABPBlog.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ABPBlog.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ABPBlogDbContextFactory : IDesignTimeDbContextFactory<ABPBlogDbContext>
    {
        public ABPBlogDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ABPBlogDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ABPBlogDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ABPBlogConsts.ConnectionStringName));

            return new ABPBlogDbContext(builder.Options);
        }
    }
}