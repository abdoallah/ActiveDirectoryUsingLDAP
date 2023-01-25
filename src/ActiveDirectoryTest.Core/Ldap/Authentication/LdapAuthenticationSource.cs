using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using ActiveDirectoryTest.Authorization.Users;
using ActiveDirectoryTest.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectoryTest.Ldap.Authentication
{
    public class LdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public LdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
        : base(settings, ldapModuleConfig)
        {

        }
    
    }
}
