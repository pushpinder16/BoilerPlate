using System.Threading.Tasks;
using BoilerPlateCrud.Configuration.Dto;

namespace BoilerPlateCrud.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
