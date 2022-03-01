using _04.kanban.Core.ModelView.Group;
using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IGroupApplication
    {
        Task<IEnumerable<Group>> FindAll();
        Task<Group> Create(GroupView entity);
        Task<Group> Update(GroupView entity);
        Task<Group> Delete(long id);
    }
}