using Abp.Configuration;
using Abp.Localization;
using Abp.Zero;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectoryTest.Ldap.Configuration
{
    public class LdapSettingProvider: SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                  {
                       new SettingDefinition(LdapSettingNames.IsEnabled, "false", L("Ldap_IsEnabled"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                       new SettingDefinition(LdapSettingNames.ContextType, ContextType.Domain.ToString(), L("Ldap_ContextType"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                       new SettingDefinition(LdapSettingNames.Container, null, L("Ldap_Container"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                       new SettingDefinition(LdapSettingNames.Domain, null, L("Ldap_Domain"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                       new SettingDefinition(LdapSettingNames.UserName, null, L("Ldap_UserName"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                       new SettingDefinition(LdapSettingNames.Password, null, L("Ldap_Password"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
                       new SettingDefinition()
                   };
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroConsts.LocalizationSourceName);
        }
    }
}
