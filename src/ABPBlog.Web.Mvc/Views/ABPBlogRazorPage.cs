using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace ABPBlog.Web.Views
{
    public abstract class ABPBlogRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ABPBlogRazorPage()
        {
            LocalizationSourceName = ABPBlogConsts.LocalizationSourceName;
        }
    }
}
