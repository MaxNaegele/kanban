using _02.kanban.Application.Interfaces.Repository;
using _03.kanban.Data.Repository;

namespace _01.kanban.WebApi.Extensions
{
    public static class InjectionsExtencionRepository
    {
        public static void AddInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IDepartamentRepository, DepartamentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
        }
    }
}