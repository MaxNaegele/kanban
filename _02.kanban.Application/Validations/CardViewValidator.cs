using _04.kanban.Core.ModelView.Card;
using FluentValidation;

namespace _02.kanban.Application.Validations
{
    public class CardViewValidator: AbstractValidator<CardView>
    {
     public CardViewValidator()
     {
         RuleFor(x=> x.GrpId).NotNull().NotEmpty();
         RuleFor(x=> x.CrdSequence).NotNull().NotEmpty().GreaterThan(0);
         RuleFor(x=> x.CrdTitle).NotNull().NotEmpty();
         RuleFor(x=> x.CrdExpectedDate).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddDays(-1));
     }
    }
}