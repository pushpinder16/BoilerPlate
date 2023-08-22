using Abp.Authorization;
using BoilerPlateCrud.Authorization.Roles;
using BoilerPlateCrud.Authorization.Users;

namespace BoilerPlateCrud.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
