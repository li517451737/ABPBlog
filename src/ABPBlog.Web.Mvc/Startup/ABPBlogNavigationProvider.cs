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
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Articles,
                        L("Articles"),
                        url: "",
                        icon: "home",
                        requiredPermissionName: PermissionNames.ABPBlog_Pages_Articles
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.ArticleInfoes,
                                L("ArticleInfoes"),
                                url: "ArticleInfoes",
                                icon: "local_offer",
                                requiredPermissionName: PermissionNames.ABPBlog_Pages_Articles
                                )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.ArticleClassify,
                                L("ArticleClassify"),
                                url: "ArticleClassify",
                                icon: "local_offer",
                                requiredPermissionName: PermissionNames.ABPBlog_Pages_ArticlesClassify
                                )
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "info"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ABPBlogConsts.LocalizationSourceName);
        }
    }
}
