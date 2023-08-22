using Abp.Application.Services;
using BoilerPlateCrud.MultiTenancy.Dto;

namespace BoilerPlateCrud.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

