using _04.kanban.Core.ModelView.Card;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Mappings
{
    public class CardMpping: Profile
    {
        public CardMpping()
        {
            CreateMap<CardView, Card>()
            .ForMember(dst => dst.CrdCreateDate, map=> map.MapFrom(_ => DateTime.Now));
        }
    }
}