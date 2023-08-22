using System.Threading.Tasks;
using Abp.Application.Services;
using BoilerPlateCrud.Sessions.Dto;

namespace BoilerPlateCrud.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
