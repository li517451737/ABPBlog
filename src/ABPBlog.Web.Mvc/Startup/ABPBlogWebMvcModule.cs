using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPBlog.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ABPBlog.Web.Startup
{
    [DependsOn(typeof(ABPBlogWebCoreModule))]
    public class ABPBlogWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ABPBlogWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<ABPBlogNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPBlogWebMvcModule).GetAssembly());
        }
    }
}