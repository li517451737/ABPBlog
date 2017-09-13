using Abp.Authorization;
using ABPBlog.Authorization.Roles;
using ABPBlog.Authorization.Users;

namespace ABPBlog.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
