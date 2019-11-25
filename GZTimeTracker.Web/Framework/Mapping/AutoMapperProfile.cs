using AutoMapper;
using GZIT.GZTimeTracker.Core.API.Models.Users;
using GZIT.GZTimeTracker.Core.Infrastructure.Entities;
using GZTimeTracker.Web.Models;

namespace GZIT.GZTimeTracker.Web.Framwork.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterModel, UserEntity>();
            CreateMap<ProjectModel, ProjectEntity>();
            CreateMap<ProjectEntity, ProjectModel>();
            CreateMap<TaskModel, TaskEntity>();
            CreateMap<TaskEntity, TaskModel>();
            CreateMap<ClientEntity, ClientModel>();
            CreateMap<ClientModel, ClientEntity>();
        }
    }
}
