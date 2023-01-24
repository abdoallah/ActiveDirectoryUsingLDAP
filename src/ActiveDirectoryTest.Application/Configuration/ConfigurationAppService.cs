using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ActiveDirectoryTest.Configuration.Dto;

namespace ActiveDirectoryTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ActiveDirectoryTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
