using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BoilerPlateCrud.Controllers
{
    public abstract class BoilerPlateCrudControllerBase: AbpController
    {
        protected BoilerPlateCrudControllerBase()
        {
            LocalizationSourceName = BoilerPlateCrudConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
