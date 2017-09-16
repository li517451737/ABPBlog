using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace ABPBlog.Configuration
{
    public class AppConfigurationAccessor : IAppConfigurationAcessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public AppConfigurationAccessor(IHostingEnvironment env)
        {
            Configuration = env.GetAppConfiguration();
        }
    }
}
