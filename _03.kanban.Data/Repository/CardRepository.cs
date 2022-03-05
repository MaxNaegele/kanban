using _02.kanban.Application.Interfaces.Repository;
using _03.kanban.Data.Context;
using kanban.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace _03.kanban.Data.Repository
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(kanbanContext context) : base(context)
        {
        }

        public override async Task<Card> InsertAsync(Card entity)
        {
            await base.InsertAsync(entity);
            await InsertTeamCard(entity);
            return entity;
        }

        public override Card UpdateAsync(Card entity)
        {
            var cardConsult = Context.Cards
            .Include(p => p.Uses)
            .SingleOrDefault(x => x.CrdId == entity.CrdId);
            if (cardConsult is not null)
            {
                Context.Entry(cardConsult).CurrentValues.SetValues(entity);
                UpdateTeamCard(entity, cardConsult);
                return base.UpdateAsync(entity);
            }
            return null;
        }

        private void UpdateTeamCard(Card entity, Card cardConsult)
        {
            cardConsult.Uses.Clear();
            foreach (var user in entity.Uses)
            {
                var userResult = Context.Users.FindAsync(user.UseId).GetAwaiter().GetResult();
                cardConsult.Uses.Add(userResult);
            }
        }

        private async Task InsertTeamCard(Card entity)
        {
            foreach (var user in entity.Uses)
            {
                var userResult = await Context.Users.AsNoTracking().FirstAsync(x => x.UseId == user.UseId);
                Context.Entry(user).CurrentValues.SetValues(userResult);
            }
        }
    }
}