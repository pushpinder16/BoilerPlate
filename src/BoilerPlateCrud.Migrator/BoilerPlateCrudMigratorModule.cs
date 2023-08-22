using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerPlateCrud.Configuration;
using BoilerPlateCrud.EntityFrameworkCore;
using BoilerPlateCrud.Migrator.DependencyInjection;

namespace BoilerPlateCrud.Migrator
{
    [DependsOn(typeof(BoilerPlateCrudEntityFrameworkModule))]
    public class BoilerPlateCrudMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public BoilerPlateCrudMigratorModule(BoilerPlateCrudEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(BoilerPlateCrudMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                BoilerPlateCrudConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerPlateCrudMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
