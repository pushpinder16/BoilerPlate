using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerPlateCrud.Authorization;

namespace BoilerPlateCrud
{
    [DependsOn(
        typeof(BoilerPlateCrudCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BoilerPlateCrudApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BoilerPlateCrudAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BoilerPlateCrudApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
