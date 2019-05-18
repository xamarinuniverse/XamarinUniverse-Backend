using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XamarinUniverse_Backend.Extensions;
using System.Text.RegularExpressions;
using XamarinUniverse_Backend.Test.TestUtils;

namespace XamarinUniverse_Backend.Test.Extensions
{
    public class StringExtensionsTest
    {
        [Fact]
        public void StringHtmlCleanupTest()
        {
            var strToTest = "<p>Crossplatfom Roadmap. This post is part of the Xamarin Roadmap that you can check if you didn't. It is good to remember that this guide ban be considered as a complement, it can not be taken as the final guide. There some things you need to know before to start this Croos platform roadmap as &#91;...&#93;</p> <p> La entrada < a rel = \"nofollow\" href = \"https://luismts.com/blog/xamarin/cross-platform-roadmap/\"> Crossplatform Roadmap </a> se publicó primero en <a rel = \"nofollow\" href = \"https://luismts.com\"> Luis Matos </a>.</p> ";
            var result = strToTest.StringHtmlCleanup();
            CommonAssert.AssertNotHtmlText(result);
        }
    }
}
