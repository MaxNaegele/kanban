using _02.kanban.Application.Interfaces.Repository;
using _03.kanban.Data.Context;
using kanban.Core.Entities;

namespace _03.kanban.Data.Repository
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(kanbanContext context) : base(context)
        {
        }
    }
}