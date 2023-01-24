using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ActiveDirectoryTest.Controllers
{
    public abstract class ActiveDirectoryTestControllerBase: AbpController
    {
        protected ActiveDirectoryTestControllerBase()
        {
            LocalizationSourceName = ActiveDirectoryTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
