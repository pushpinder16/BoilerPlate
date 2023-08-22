using Abp.AutoMapper;
using BoilerPlateCrud.Roles.Dto;
using BoilerPlateCrud.Web.Models.Common;

namespace BoilerPlateCrud.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
