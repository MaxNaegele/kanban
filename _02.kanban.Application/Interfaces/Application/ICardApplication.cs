using _04.kanban.Core.ModelView.Card;
using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface ICardApplication
    {
        Task<IEnumerable<CardResponseView>> FindAll(long grpId);
        Task<Card> Create(CardView model);
        Task<Card> Update(CardUpdateView model);
    }
}