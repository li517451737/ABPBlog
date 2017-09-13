using Abp.AspNetCore.Mvc.ViewComponents;

namespace ABPBlog.Web.Views
{
    public abstract class ABPBlogViewComponent : AbpViewComponent
    {
        protected ABPBlogViewComponent()
        {
            LocalizationSourceName = ABPBlogConsts.LocalizationSourceName;
        }
    }
}