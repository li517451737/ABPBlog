using System.Threading.Tasks;
using ABPBlog.Configuration.Dto;

namespace ABPBlog.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}