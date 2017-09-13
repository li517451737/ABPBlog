using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABPBlog.MultiTenancy.Dto;

namespace ABPBlog.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
