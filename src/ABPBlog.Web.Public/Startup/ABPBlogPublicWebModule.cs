using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPBlog.Configuration;
using ABPBlog.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABPBlog.Web.Public.Startup
{
    [DependsOn(typeof(ABPBlogWebCoreModule))]
    public class ABPBlogPublicWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ABPBlogPublicWebModule(IHostingEnvironment env, ABPBlogEntityFrameworkModule abpZeroEntityFrameworkModule)
        {
            this._appConfiguration = env.GetAppConfiguration();
            abpZeroEntityFrameworkModule.SkipDbSeed = true;
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = _appConfiguration["App:WebSiteRootAddress"] ?? "http://localhost:45776";

            Configuration.Modules.AbpWebCommon().AntiForgery.TokenCookieName = "Public-XSRF-TOKEN";
            Configuration.Modules.AbpWebCommon().AntiForgery.TokenHeaderName = "Public-X-XSRF-TOKEN";
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            //Configuration.Navigation.Providers.Add<>();   
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPBlogPublicWebModule).GetAssembly());
        }
    }
}
