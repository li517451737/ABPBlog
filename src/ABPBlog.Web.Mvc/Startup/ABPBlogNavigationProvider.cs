using Abp.Application.Navigation;
using Abp.Localization;
using ABPBlog.Authorization;

namespace ABPBlog.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class ABPBlogNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fa fa-cubes",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fa fa-user-o",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Articles,
                        L("ABPBlog_Pages_ArticlesManager"),
                        url: "",
                        icon: "fa fa-file",
                        requiredPermissionName: PermissionNames.ABPBlog_Pages_Articles
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.ArticleInfoes,
                                L("ABPBlog_Pages_Articles"),
                                url: "ArticleInfoes",
                                icon: "fa fa-book",
                                requiredPermissionName: PermissionNames.ABPBlog_Pages_Articles
                                )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.ArticleClassify,
                                L("ABPBlog_Pages_ArticlesClassify"),
                                url: "ArticleClassifies",
                                icon: "fa fa-bars",
                                requiredPermissionName: PermissionNames.ABPBlog_Pages_ArticlesClassify
                                )
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fa fa-info-circle"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ABPBlogConsts.LocalizationSourceName);
        }
    }
}
