using System.Threading.Tasks;
using Abp.Application.Services;
using TestProject.Configuration.Dto;

namespace TestProject.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}