using Abp.Localization;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using ActiveDirectoryTest.Authorization.Roles;
using ActiveDirectoryTest.Authorization.Users;
using ActiveDirectoryTest.Configuration;
using ActiveDirectoryTest.Ldap;
using ActiveDirectoryTest.Ldap.Authentication;
using ActiveDirectoryTest.Localization;
using ActiveDirectoryTest.MultiTenancy;
using ActiveDirectoryTest.Timing;
using System.Reflection;

namespace ActiveDirectoryTest
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ActiveDirectoryTestCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            Configuration.Modules.ZeroLdap().Enable(typeof(LdapAuthenticationSource));

            IocManager.Register<IAbpZeroLdapModuleConfig, AbpZeroLdapModuleConfig>();

            Configuration.Localization.Sources.Extensions.Add(
                new LocalizationSourceExtensionInfo(
                    AbpZeroConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "ActiveDirectoryTest.Core.Ldap.LocalizationSource.Source")
                    )
                );

            Configuration.Settings.Providers.Add<LdapSettingProvider>();


            ActiveDirectoryTestLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = ActiveDirectoryTestConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = ActiveDirectoryTestConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = ActiveDirectoryTestConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ActiveDirectoryTestCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
