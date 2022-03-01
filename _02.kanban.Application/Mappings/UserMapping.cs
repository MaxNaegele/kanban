using _04.kanban.Core.ModelView.User;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Mappings
{
    public class UserMapping: Profile
    {
        public UserMapping()
        {
            CreateMap<UserView, User>()
            .ForMember(dst => dst.UseCreateDate, map=> map.MapFrom(_ => DateTime.Now));
        }
    }
}