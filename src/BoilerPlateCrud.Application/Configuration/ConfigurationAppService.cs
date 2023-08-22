using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BoilerPlateCrud.Configuration.Dto;

namespace BoilerPlateCrud.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BoilerPlateCrudAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
