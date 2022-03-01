using _04.kanban.Core.ModelView.Departament;
using FluentValidation;

namespace _02.kanban.Application.Validations
{
    public class DepartamentViewValidator: AbstractValidator<DepartamentView>
    {
     public DepartamentViewValidator()
     {
         RuleFor(x=> x.DptName).NotNull().NotEmpty();
     }
    }
}