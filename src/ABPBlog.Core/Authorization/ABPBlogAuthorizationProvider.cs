using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ABPBlog.Authorization
{
    public class ABPBlogAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.ABPBlog_Pages_Articles, L("ABPBlog_Pages_Articles"));
            context.CreatePermission(PermissionNames.ABPBlog_Pages_ArticlesClassify, L("ABPBlog_Pages_ArticlesClassify"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ABPBlogConsts.LocalizationSourceName);
        }
    }
}
