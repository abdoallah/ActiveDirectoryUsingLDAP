using System.Threading.Tasks;
using ActiveDirectoryTest.Configuration.Dto;

namespace ActiveDirectoryTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
