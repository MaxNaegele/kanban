using _04.kanban.Core.ModelView.Group;
using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IGroupApplication
    {
        Task<IEnumerable<Group>> FindAll(long BrdId);
        Task<Group> Create(GroupView entity);
        Task<Group> Update(GroupUpdateView entity);
        Task Delete(long id);
    }
}