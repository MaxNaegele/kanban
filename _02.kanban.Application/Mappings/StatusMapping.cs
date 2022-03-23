using _04.kanban.Core.ModelView.Status;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Mappings
{
    public class StatusMapping: Profile
    {
        public StatusMapping()
        {
            CreateMap<StatusView, Status>().ReverseMap();
        }
    }
}