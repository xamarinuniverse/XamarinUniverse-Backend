using Microsoft.SyndicationFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinUniverse_Backend.Models;

namespace XamarinUniverse_Backend.Services
{
    public interface IPlanetXamarinService
    {
        /// <summary>
        /// Get all feeds from planet xamarin.
        /// </summary>
        /// <returns>All feeds</returns>
        Task<IEnumerable<CustomSyndicationItem>> GetAllFeeds();

        /// <summary>
        /// Get all feeds from planet xamarin by category.
        /// </summary>
        /// <param name="category">Feed category</param>
        /// <returns>All feeds that has the input category</returns>
        Task<IEnumerable<CustomSyndicationItem>> GetFeedsByCategory(string category);

        /// <summary>
        /// Get the a single item on feed located at input order.
        /// </summary>
        /// <param name="order">Order of item startet at 1</param>
        /// <returns>RSS Syndication item</returns>
        Task<CustomSyndicationItem> GetFeedsByOrder(int order);

        /// <summary>
        /// Get the a single item on feed located at input order by Category.
        /// </summary>
        /// <param name="order">Order of item startet at 1</param>
        /// <param name="category">Feed category</param>
        /// <returns></returns>
        Task<CustomSyndicationItem> GetFeedsByCategoryOrder(int order, string category);
    }
}
