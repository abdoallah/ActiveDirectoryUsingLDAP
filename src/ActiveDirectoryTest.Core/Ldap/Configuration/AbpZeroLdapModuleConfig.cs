using Abp.Zero.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectoryTest.Ldap.Configuration
{
    public class AbpZeroLdapModuleConfig : IAbpZeroLdapModuleConfig
    {
        public bool IsEnabled { get; private set; }

        public Type AuthenticationSourceType { get; private set; }

        private readonly IAbpZeroConfig _zeroConfig;

        public AbpZeroLdapModuleConfig(IAbpZeroConfig zeroConfig)
        {
            _zeroConfig = zeroConfig;
        }

        public void Enable(Type authenticationSourceType)
        {
            AuthenticationSourceType = authenticationSourceType;
            IsEnabled = true;

            _zeroConfig.UserManagement.ExternalAuthenticationSources.Add(authenticationSourceType);
        }
    }
}
