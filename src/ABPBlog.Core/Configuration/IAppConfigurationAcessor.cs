using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Configuration
{
    public interface IAppConfigurationAcessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
