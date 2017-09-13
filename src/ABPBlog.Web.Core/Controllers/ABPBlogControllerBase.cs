using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ABPBlog.Controllers
{
    public abstract class ABPBlogControllerBase: AbpController
    {
        protected ABPBlogControllerBase()
        {
            LocalizationSourceName = ABPBlogConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}