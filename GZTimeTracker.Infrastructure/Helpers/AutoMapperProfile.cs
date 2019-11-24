using AutoMapper;
using GZIT.GZTimeTracker.Core.API.Models.Users;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZIT.GZTimeTracker.Infrastructure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterModel, UserEntity>();
        }
    }
}
