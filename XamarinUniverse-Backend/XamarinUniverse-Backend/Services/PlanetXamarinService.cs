using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace XamarinUniverse_Backend.Services
{
    public class PlanetXamarinService : IPlanetXamarinService
    {
        private readonly string _url;

        public PlanetXamarinService()
        {
            _url = "https://www.planetxamarin.com/feed";
        }
        public async Task<IEnumerable<ISyndicationItem>> GetAllFeeds()
        {
            var items = new List<ISyndicationItem>();
            using (var xmlReader = XmlReader.Create(_url, new XmlReaderSettings() { Async = true }))
            {
                var feedReader = new RssFeedReader(xmlReader);
                while (await feedReader.Read())
                {
                    if (feedReader.ElementType == SyndicationElementType.Item)
                    {
                        items.Add(await feedReader.ReadItem());
                    }

                }
            }
            return items;
        }
        public async Task<IEnumerable<ISyndicationItem>> GetFeedsByCategory(string category)
        {
            return (await GetAllFeeds())
                .Where(i => i.Categories.Where(cat => cat.Name == category).Any());
        }
        public async Task<ISyndicationItem> GetFeedsByOrder(int order)
        {
            var feeds = await GetAllFeeds();
            return EnsureOrder(feeds, order)
                ? feeds.Skip(order - 1).FirstOrDefault() : null;
        }
        public async Task<ISyndicationItem> GetFeedsByCategoryOrder(int order, string category)
        {
            var feeds = await GetFeedsByCategory(category);
            return EnsureOrder(feeds, order)
                ? feeds.Skip(order - 1).FirstOrDefault() : null;
        }

        //Ensure that has more than 0 elements and order less and equals than elements
        private bool EnsureOrder(IEnumerable<ISyndicationItem> feeds, int order)
        {
            return order < feeds.Count() && feeds.Count() > 0;
        }
    }
}
