using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ABPBlog.Configuration.Dto;

namespace ABPBlog.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ABPBlogAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
