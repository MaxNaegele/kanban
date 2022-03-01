using _04.kanban.Core.ModelView.Departament;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Mappings
{
    public class DepartamentMapping: Profile
    {
        public DepartamentMapping()
        {
            CreateMap<DepartamentView, Departament>()
            .ForMember(dst => dst.DptCreateDate, map=> map.MapFrom(_ => DateTime.Now));
        }
    }
}