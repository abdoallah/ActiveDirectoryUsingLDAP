using Abp.Zero.Ldap.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectoryTest.Ldap.Configuration
{
    public class LdapSettings : ILdapSettings
    {
        public Task<string> GetContainer(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<ContextType> GetContextType(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDomain(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetIsEnabled(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPassword(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserName(int? tenantId)
        {
            throw new NotImplementedException();
        }
    }
}
