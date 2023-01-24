using System.Threading.Tasks;
using ActiveDirectoryTest.Models.TokenAuth;
using ActiveDirectoryTest.Web.Controllers;
using Shouldly;
using Xunit;

namespace ActiveDirectoryTest.Web.Tests.Controllers
{
    public class HomeController_Tests: ActiveDirectoryTestWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}