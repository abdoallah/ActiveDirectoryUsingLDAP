using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ActiveDirectoryTest.Authorization.Roles;
using ActiveDirectoryTest.Authorization.Users;
using ActiveDirectoryTest.MultiTenancy;

namespace ActiveDirectoryTest.EntityFrameworkCore
{
    public class ActiveDirectoryTestDbContext : AbpZeroDbContext<Tenant, Role, User, ActiveDirectoryTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ActiveDirectoryTestDbContext(DbContextOptions<ActiveDirectoryTestDbContext> options)
            : base(options)
        {
        }
    }
}
