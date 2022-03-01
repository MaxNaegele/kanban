using _04.kanban.Core.ModelView.Board;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Mappings
{
    public class BoardMapping: Profile
    {
        public BoardMapping()
        {
            CreateMap<BoardView, Board>()
            .ForMember(dst => dst.BrdCreateDate, map=> map.MapFrom(_ => DateTime.Now));
        }
    }
}