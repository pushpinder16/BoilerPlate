using Abp.AspNetCore.Mvc.ViewComponents;

namespace BoilerPlateCrud.Web.Views
{
    public abstract class BoilerPlateCrudViewComponent : AbpViewComponent
    {
        protected BoilerPlateCrudViewComponent()
        {
            LocalizationSourceName = BoilerPlateCrudConsts.LocalizationSourceName;
        }
    }
}
