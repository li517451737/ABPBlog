using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABPBlog.Authorization.Users;
using ABPBlog.Users;

namespace ABPBlog.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
