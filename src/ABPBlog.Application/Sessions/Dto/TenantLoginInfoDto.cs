using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABPBlog.MultiTenancy;

namespace ABPBlog.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}