using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IStatusApplication
    {
        Task<IEnumerable<Status>> FindAll();
        Task<Status> Create(Status entity);
        Task<Status> Update(Status entity);
    }
}