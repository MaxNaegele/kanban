using System.Globalization;
using _02.kanban.Application.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace _01.kanban.WebApi.Extensions
{
    public static class AddFluentValidationExtension
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();

                    options.Filters.Add(new AuthorizeFilter(policy));
                })
            .AddFluentValidation(p =>
          {
              p.RegisterValidatorsFromAssemblyContaining<BoardViewValidator>();
              p.RegisterValidatorsFromAssemblyContaining<CardViewValidator>();
              p.RegisterValidatorsFromAssemblyContaining<CardUpdateViewValidator>();
              p.RegisterValidatorsFromAssemblyContaining<DepartamentViewValidator>();
              p.RegisterValidatorsFromAssemblyContaining<GroupViewValidator>();
              p.RegisterValidatorsFromAssemblyContaining<StatusViewValidator>();
              p.RegisterValidatorsFromAssemblyContaining<StatusViewValidator>();
              p.RegisterValidatorsFromAssemblyContaining<UserViewValidator>();
              p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
          });
        }
    }
}