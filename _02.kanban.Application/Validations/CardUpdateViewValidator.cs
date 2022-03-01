using _04.kanban.Core.ModelView.Card;
using FluentValidation;

namespace _02.kanban.Application.Validations
{
    public class CardUpdateViewValidator: AbstractValidator<CardUpdateView>
    {
     public CardUpdateViewValidator()
     {
         RuleFor(x=> x.CrdId).NotNull().NotEmpty();
         Include(new CardViewValidator());
     }
    }
}