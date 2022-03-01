using _04.kanban.Core.ModelView.User;
using FluentValidation;

namespace _02.kanban.Application.Validations
{
    public class UserViewValidator: AbstractValidator<UserView>
    {
     public UserViewValidator()
     {
         RuleFor(x=> x.UsePassword).NotNull().NotEmpty();
         RuleFor(x=> x.UseName).NotNull().NotEmpty();
         RuleFor(x=> x.UseEmail).NotNull().NotEmpty().EmailAddress();
     }
    }
}