using _04.kanban.Core.ModelView.Group;
using FluentValidation;

namespace _02.kanban.Application.Validations
{
    public class GroupViewValidator: AbstractValidator<GroupView>
    {
     public GroupViewValidator()
     {         
         RuleFor(x=> x.BrdId).NotNull().NotEmpty().GreaterThan(0);
         RuleFor(x=> x.GrpTitle).NotNull().NotEmpty();
         RuleFor(x=> x.GrpSequence).NotNull().NotEmpty().GreaterThan(0);
     }
    }
}