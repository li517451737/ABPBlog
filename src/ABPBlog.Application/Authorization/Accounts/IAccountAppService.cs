using System.Threading.Tasks;
using Abp.Application.Services;
using ABPBlog.Authorization.Accounts.Dto;

namespace ABPBlog.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
