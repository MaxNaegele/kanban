using System.Globalization;
using _02.kanban.Application.Mappings;
using _02.kanban.Application.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace _01.kanban.WebApi.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperExtension(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(BoardMapping),
                typeof(CardMpping),
                typeof(DepartamentMapping),
                typeof(StatusMapping),
                typeof(UserMapping),
                typeof(GroupMapping));
        }
    }
}