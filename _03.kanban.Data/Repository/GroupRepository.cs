using _02.kanban.Application.Interfaces.Repository;
using _03.kanban.Data.Context;
using kanban.Core.Entities;

namespace _03.kanban.Data.Repository
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(kanbanContext context) : base(context)
        {
        }
    }
}