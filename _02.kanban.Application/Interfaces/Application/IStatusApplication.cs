using _04.kanban.Core.ModelView.Status;
using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IStatusApplication
    {
        Task<IEnumerable<Status>> FindAll();
        Task<Status> Create(StatusView model);
    }
}