using _04.kanban.Core.ModelView.Card;
using FluentValidation;

namespace _02.kanban.Application.Validations
{
    public class CardViewValidator: AbstractValidator<CardView>
    {
     public CardViewValidator()
     {
         RuleFor(x=> x.GrpId).NotNull().NotEmpty();
         RuleFor(x=> x.SttId).NotNull().NotEmpty();
         RuleFor(x=> x.CrdSequence).NotNull().NotEmpty().LessThan(1);
         RuleFor(x=> x.CrdTitle).NotNull().NotEmpty();
         RuleFor(x=> x.CrdExpectedDate).NotNull().NotEmpty().LessThan(DateTime.Now);
     }
    }
}