using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ActiveDirectoryTest.Configuration;
using ActiveDirectoryTest.EntityFrameworkCore;
using ActiveDirectoryTest.Migrator.DependencyInjection;

namespace ActiveDirectoryTest.Migrator
{
    [DependsOn(typeof(ActiveDirectoryTestEntityFrameworkModule))]
    public class ActiveDirectoryTestMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ActiveDirectoryTestMigratorModule(ActiveDirectoryTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ActiveDirectoryTestMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ActiveDirectoryTestConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(ActiveDirectoryTestMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
