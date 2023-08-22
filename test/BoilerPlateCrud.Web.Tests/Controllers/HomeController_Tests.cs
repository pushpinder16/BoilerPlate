using System.Threading.Tasks;
using BoilerPlateCrud.Models.TokenAuth;
using BoilerPlateCrud.Web.Controllers;
using Shouldly;
using Xunit;

namespace BoilerPlateCrud.Web.Tests.Controllers
{
    public class HomeController_Tests: BoilerPlateCrudWebTestBase
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