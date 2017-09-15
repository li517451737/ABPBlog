using Abp.Application.Navigation;

namespace ABPBlog.Web.Views.Shared.Components.SideBarNav
{
    public class UserMenuItemViewModel
    {
        public UserMenuItem MenuItem { get; set; }

        public string CurrentPageName { get; set; }

        public int MenuItemIndex { get; set; }

        public bool RootLevel { get; set; }
    }
}
