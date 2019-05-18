using System;
using System.Collections.Generic;
using System.Text;
using XamarinUniverse_Backend.Models;
using Xunit;

namespace XamarinUniverse_Backend.Test.TestUtils
{
    public class CommonAssert
    {
        public static void AssertNotHtmlText(string supreciousStr)
        {
            Assert.DoesNotMatch(@"&.*?;", supreciousStr);
        }

        public static void AssertCleanAllDescription(IEnumerable<CustomSyndicationItem>all)
        {
            foreach (var item in all)
            {
                AssertNotHtmlText(item.CleanDescription);
            }
        }
    }
}
