using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABPBlog.Web.Public.Startup
{
    public class ABPBlogPublicNavigationProvider : NavigationProvider
    {
        public const string MenuName = "PublicNavigation";
        public override void SetNavigation(INavigationProviderContext context)
        {
            var publicMenu = new MenuDefinition(MenuName, new FixedLocalizableString("PublicMenu"));
            context.Manager.Menus[MenuName] = publicMenu;
            publicMenu.AddItem(new MenuItemDefinition(
                PublicPagesName.Home,
                L("Home"),
                url: ""
                ));



        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ABPBlogConsts.LocalizationSourceName);
        }
    }
}
