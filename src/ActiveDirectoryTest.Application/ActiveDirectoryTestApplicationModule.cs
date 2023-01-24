using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ActiveDirectoryTest.Authorization;

namespace ActiveDirectoryTest
{
    [DependsOn(
        typeof(ActiveDirectoryTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ActiveDirectoryTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ActiveDirectoryTestAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ActiveDirectoryTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
