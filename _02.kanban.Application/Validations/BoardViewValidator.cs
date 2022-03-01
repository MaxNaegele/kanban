using _04.kanban.Core.ModelView.Board;
using FluentValidation;

namespace _02.kanban.Application.Validations
{
    public class BoardViewValidator: AbstractValidator<BoardView>
    {
     public BoardViewValidator()
     {
         RuleFor(x=> x.BrdName).NotNull().NotEmpty();
     }
    }
}