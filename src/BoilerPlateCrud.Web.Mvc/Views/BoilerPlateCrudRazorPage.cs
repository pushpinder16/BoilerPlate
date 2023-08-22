using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace BoilerPlateCrud.Web.Views
{
    public abstract class BoilerPlateCrudRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BoilerPlateCrudRazorPage()
        {
            LocalizationSourceName = BoilerPlateCrudConsts.LocalizationSourceName;
        }
    }
}
