using _02.kanban.Application.Interfaces.Repository;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _03.kanban.Data.Repository;
using _03.kanban.Data.UnityOfWork;

namespace _01.kanban.WebApi.Extensions
{
    public static class InjectionsRepositoryExtension
    {
        public static void AddInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IDepartamentRepository, DepartamentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
        }
    }
}