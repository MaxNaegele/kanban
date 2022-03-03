using _04.kanban.Core.Model;
using _04.kanban.Core.ModelView.Board;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Mappings
{
    public class DataUserMapping : Profile
    {
        public DataUserMapping()
        {
            CreateMap<User, DataUser>()
            .ForMember(dst => dst.Id, map => map.MapFrom(x=> x.UseId))
            .ForMember(dst => dst.Email, map => map.MapFrom(x=> x.UseEmail))
            .ForMember(dst => dst.Name, map => map.MapFrom(x=> x.UseName));
        }
    }
}