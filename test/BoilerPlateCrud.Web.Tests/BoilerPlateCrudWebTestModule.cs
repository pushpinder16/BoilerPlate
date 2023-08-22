using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerPlateCrud.EntityFrameworkCore;
using BoilerPlateCrud.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BoilerPlateCrud.Web.Tests
{
    [DependsOn(
        typeof(BoilerPlateCrudWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BoilerPlateCrudWebTestModule : AbpModule
    {
        public BoilerPlateCrudWebTestModule(BoilerPlateCrudEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerPlateCrudWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BoilerPlateCrudWebMvcModule).Assembly);
        }
    }
}