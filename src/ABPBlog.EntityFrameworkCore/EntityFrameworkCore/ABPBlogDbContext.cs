using Abp.Zero.EntityFrameworkCore;
using ABPBlog.Authorization.Roles;
using ABPBlog.Authorization.Users;
using ABPBlog.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace ABPBlog.EntityFrameworkCore
{
    public class ABPBlogDbContext : AbpZeroDbContext<Tenant, Role, User, ABPBlogDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public ABPBlogDbContext(DbContextOptions<ABPBlogDbContext> options)
            : base(options)
        {

        }
    }
}
