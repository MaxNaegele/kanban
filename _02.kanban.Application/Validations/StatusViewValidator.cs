using _04.kanban.Core.ModelView.Status;
using FluentValidation;

namespace _02.kanban.Application.Validations
{
    public class StatusViewValidator: AbstractValidator<StatusView>
    {
     public StatusViewValidator()
     {
         RuleFor(x=> x.SttColor).NotNull().NotEmpty();
         RuleFor(x=> x.SttDescription).NotNull().NotEmpty();
     }
    }
}