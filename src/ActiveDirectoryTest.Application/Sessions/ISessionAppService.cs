using System.Threading.Tasks;
using Abp.Application.Services;
using ActiveDirectoryTest.Sessions.Dto;

namespace ActiveDirectoryTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
