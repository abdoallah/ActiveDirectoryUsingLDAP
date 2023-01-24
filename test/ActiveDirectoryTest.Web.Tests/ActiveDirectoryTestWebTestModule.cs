using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ActiveDirectoryTest.EntityFrameworkCore;
using ActiveDirectoryTest.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ActiveDirectoryTest.Web.Tests
{
    [DependsOn(
        typeof(ActiveDirectoryTestWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ActiveDirectoryTestWebTestModule : AbpModule
    {
        public ActiveDirectoryTestWebTestModule(ActiveDirectoryTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ActiveDirectoryTestWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ActiveDirectoryTestWebMvcModule).Assembly);
        }
    }
}