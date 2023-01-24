using Abp.Authorization;
using ActiveDirectoryTest.Authorization.Roles;
using ActiveDirectoryTest.Authorization.Users;

namespace ActiveDirectoryTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
