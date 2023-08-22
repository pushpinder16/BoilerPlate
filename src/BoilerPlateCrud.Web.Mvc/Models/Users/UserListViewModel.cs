using System.Collections.Generic;
using BoilerPlateCrud.Roles.Dto;

namespace BoilerPlateCrud.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
