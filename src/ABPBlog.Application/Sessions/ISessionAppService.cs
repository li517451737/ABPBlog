using System.Threading.Tasks;
using Abp.Application.Services;
using ABPBlog.Sessions.Dto;

namespace ABPBlog.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
