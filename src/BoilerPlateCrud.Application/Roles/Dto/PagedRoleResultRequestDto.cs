using Abp.Application.Services.Dto;

namespace BoilerPlateCrud.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

