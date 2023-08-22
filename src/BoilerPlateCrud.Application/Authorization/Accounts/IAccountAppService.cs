using System.Threading.Tasks;
using Abp.Application.Services;
using BoilerPlateCrud.Authorization.Accounts.Dto;

namespace BoilerPlateCrud.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
