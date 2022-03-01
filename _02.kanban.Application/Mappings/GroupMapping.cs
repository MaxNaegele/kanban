using _04.kanban.Core.ModelView.Group;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Mappings
{
    public class GroupMapping: Profile
    {
        public GroupMapping()
        {
            CreateMap<GroupView, Group>()
            .ForMember(dst => dst.GrpCreateDate, map=> map.MapFrom(_ => DateTime.Now));
        }
    }
}