using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ActiveDirectoryTest.Configuration;

namespace ActiveDirectoryTest.Web.Host.Startup
{
    [DependsOn(
       typeof(ActiveDirectoryTestWebCoreModule))]
    public class ActiveDirectoryTestWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ActiveDirectoryTestWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ActiveDirectoryTestWebHostModule).GetAssembly());
        }
    }
}
