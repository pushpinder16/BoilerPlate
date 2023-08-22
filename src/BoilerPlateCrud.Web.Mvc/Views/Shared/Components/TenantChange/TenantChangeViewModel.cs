using Abp.AutoMapper;
using BoilerPlateCrud.Sessions.Dto;

namespace BoilerPlateCrud.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
