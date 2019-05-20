using Microsoft.SyndicationFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinUniverse_Backend.Extensions;

namespace XamarinUniverse_Backend.Models
{
    public class CustomSyndicationItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<ISyndicationCategory> Categories { get; set; }
        public IEnumerable<ISyndicationPerson> Contributors { get; set; }
        public IEnumerable<ISyndicationLink> Links { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset Published { get; set; }
        public string CleanDescription { get { return Description.StringHtmlCleanup(); } }
    }
}
