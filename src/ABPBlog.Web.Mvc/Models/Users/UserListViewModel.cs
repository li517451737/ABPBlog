using System.Collections.Generic;
using ABPBlog.Roles.Dto;
using ABPBlog.Users.Dto;

namespace ABPBlog.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}