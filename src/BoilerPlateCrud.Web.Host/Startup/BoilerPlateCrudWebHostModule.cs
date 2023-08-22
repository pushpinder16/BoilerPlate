using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerPlateCrud.Configuration;

namespace BoilerPlateCrud.Web.Host.Startup
{
    [DependsOn(
       typeof(BoilerPlateCrudWebCoreModule))]
    public class BoilerPlateCrudWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BoilerPlateCrudWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerPlateCrudWebHostModule).GetAssembly());
        }
    }
}
