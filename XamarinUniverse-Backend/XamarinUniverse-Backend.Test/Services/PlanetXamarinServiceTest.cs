using AutoMapper;
using System.Linq;
using XamarinUniverse_Backend.Services;
using XamarinUniverse_Backend.Test.TestUtils;
using Xunit;

namespace XamarinUniverse_Backend.Test.Services
{
    public class PlanetXamarinServiceTest
    {
        private IMapper mockMapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AppMappingProfile());
        }).CreateMapper();

        [Fact]
        public async void GetAllFeedsTest()
        {
            
            var all = await new PlanetXamarinService(mockMapper).GetAllFeeds();
            CommonAssert.AssertCleanAllDescription(all);
        }

        [Fact]
        public async void GetFeedsByCategoryTest()
        {
            var all = await new PlanetXamarinService(mockMapper).GetFeedsByCategory("Xamarin");
            CommonAssert.AssertCleanAllDescription(all);
        }

        [Fact]
        public async void GetFeedsByOrderTest()
        {
            var once = await new PlanetXamarinService(mockMapper).GetFeedsByOrder(1);
            CommonAssert.AssertNotHtmlText(once.CleanDescription);
        }

        [Fact]
        public async void GetFeedsByCategoryOrderTest()
        {
            var once = await new PlanetXamarinService(mockMapper).GetFeedsByCategoryOrder(1, "Xamarin");
            CommonAssert.AssertNotHtmlText(once.CleanDescription);
        }

    }
}
