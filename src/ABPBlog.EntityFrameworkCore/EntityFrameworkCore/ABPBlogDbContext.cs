using Abp.Zero.EntityFrameworkCore;
using ABPBlog.Articles;
using ABPBlog.Authorization.Roles;
using ABPBlog.Authorization.Users;
using ABPBlog.MultiTenancy;
using ABPBlog.Photos;
using Microsoft.EntityFrameworkCore;

namespace ABPBlog.EntityFrameworkCore
{
    public class ABPBlogDbContext : AbpZeroDbContext<Tenant, Role, User, ABPBlogDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        public DbSet<ArticleInfo> ArticleInfoes { get; set; }

        public DbSet<ArticleClassify> ArticleClassifies { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }

        public ABPBlogDbContext(DbContextOptions<ABPBlogDbContext> options)
            : base(options)
        {

        }
    }
}
