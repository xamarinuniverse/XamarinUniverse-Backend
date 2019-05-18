using AutoMapper;
using Microsoft.SyndicationFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinUniverse_Backend.Models;

namespace XamarinUniverse_Backend
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<SyndicationItem, CustomSyndicationItem>().ReverseMap();
        }
    }
}
