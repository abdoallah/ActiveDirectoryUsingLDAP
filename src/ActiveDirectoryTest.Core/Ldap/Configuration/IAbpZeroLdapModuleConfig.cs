using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectoryTest.Ldap.Configuration
{
    public interface IAbpZeroLdapModuleConfig
    {
        bool IsEnabled { get; }

        Type AuthenticationSourceType { get; }

        void Enable(Type authenticationSourceType);
    }
}
