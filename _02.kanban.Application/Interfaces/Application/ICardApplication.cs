using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface ICardApplication
    {
        Task<IEnumerable<Card>> FindAll(string search);
        Task<Card> Create(Card entity);
        Task<Card> Update(Card entity);
    }
}