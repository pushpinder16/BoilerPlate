using System.Collections.Generic;
using BoilerPlateCrud.Roles.Dto;

namespace BoilerPlateCrud.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
