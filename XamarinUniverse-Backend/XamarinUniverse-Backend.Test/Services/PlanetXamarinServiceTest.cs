using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XamarinUniverse_Backend.Services;
using Xunit;

namespace XamarinUniverse_Backend.Test.Services
{
    public class PlanetXamarinServiceTest
    {
        [Fact]
        public void GetAllFeedsTest()
        {
            var all = new PlanetXamarinService().GetAllFeeds();
        }

        [Fact]
        public void GetFeedsByCategoryTest()
        {
            var all = new PlanetXamarinService().GetFeedsByCategory("MVP2019");
        }

        [Fact]
        public void GetFeedsByOrderTest()
        {
            var all = new PlanetXamarinService().GetFeedsByOrder(1);
        }

        [Fact]
        public void GetFeedsByCategoryOrderTest()
        {
            var all = new PlanetXamarinService().GetFeedsByCategoryOrder(1, "MVP2019");
        }

    }
}
