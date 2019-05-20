using AutoMapper;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using XamarinUniverse_Backend.Models;

namespace XamarinUniverse_Backend.Services
{
    public class PlanetXamarinService : IPlanetXamarinService
    {
        private readonly string _url;
        private readonly IMapper _mapper;

        public PlanetXamarinService(IMapper mapper)
        {
            _url = "https://www.planetxamarin.com/feed";
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomSyndicationItem>> GetAllFeeds()
        {
            var items = new List<CustomSyndicationItem>();
            using (var xmlReader = XmlReader.Create(_url, new XmlReaderSettings() { Async = true }))
            {
                var feedReader = new RssFeedReader(xmlReader);
                while (await feedReader.Read())
                {
                    if (feedReader.ElementType == SyndicationElementType.Item)
                    {
                        var item = _mapper.Map<CustomSyndicationItem>(await feedReader.ReadItem());
                        items.Add(item);
                    }

                }
            }
            return items;
        }
        public async Task<IEnumerable<CustomSyndicationItem>> GetFeedsByCategory(string category)
        {
            return (await GetAllFeeds())
                .Where(i => i.Categories.Where(cat => cat.Name == category).Any());
        }
        public async Task<CustomSyndicationItem> GetFeedsByOrder(int order)
        {
            var feeds = await GetAllFeeds();
            return EnsureOrder(feeds, order)
                ? feeds.Skip(order - 1).FirstOrDefault() : null;
        }
        public async Task<CustomSyndicationItem> GetFeedsByCategoryOrder(int order, string category)
        {
            var feeds = await GetFeedsByCategory(category);
            return EnsureOrder(feeds, order)
                ? feeds.Skip(order - 1).FirstOrDefault() : null;
        }

        //Ensure that has more than 0 elements and order less and equals than elements
        private bool EnsureOrder(IEnumerable<CustomSyndicationItem> feeds, int order)
        {
            return order < feeds.Count() && feeds.Count() > 0;
        }
    }
}
