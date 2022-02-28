using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IGroupApplication
    {
        Task<IEnumerable<Group>> FindAll();
        Task<Group> Create(Group entity);
        Task<Group> Update(Group entity);
        Task<Group> Delete(Group entity);
    }
}