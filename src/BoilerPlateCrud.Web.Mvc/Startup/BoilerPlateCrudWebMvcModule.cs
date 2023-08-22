using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerPlateCrud.Configuration;

namespace BoilerPlateCrud.Web.Startup
{
    [DependsOn(typeof(BoilerPlateCrudWebCoreModule))]
    public class BoilerPlateCrudWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BoilerPlateCrudWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<BoilerPlateCrudNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerPlateCrudWebMvcModule).GetAssembly());
        }
    }
}
