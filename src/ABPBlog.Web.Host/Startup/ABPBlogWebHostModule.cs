using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPBlog.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ABPBlog.Web.Host.Startup
{
    [DependsOn(
       typeof(ABPBlogWebCoreModule))]
    public class ABPBlogWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ABPBlogWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPBlogWebHostModule).GetAssembly());
        }
    }
}
