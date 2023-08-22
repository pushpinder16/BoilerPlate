using System.Collections.Generic;
using BoilerPlateCrud.Roles.Dto;

namespace BoilerPlateCrud.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}