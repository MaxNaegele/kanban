using _04.kanban.Core.ModelView.Card;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Mappings
{
    public class CardMpping : Profile
    {
        public CardMpping()
        {
            CreateMap<CardView, Card>()
            .ForMember(dst => dst.CrdCreateDate, map => map.MapFrom(_ => DateTime.Now))
            .ForMember(dst => dst.CrdBalanceTime, map => map.MapFrom(src => ParseStringTimeOnly(src.CrdBalanceTime)))
            .ForMember(dst => dst.CrdEstimatedTime, map => map.MapFrom(src => ParseStringTimeOnly(src.CrdEstimatedTime)));
        }

        private TimeOnly? ParseStringTimeOnly(string? value)
        {
            if (String.IsNullOrEmpty(value))
                return null;
            TimeOnly time;
            TimeOnly.TryParse(value, out time);
            return time;

        }
    }
}