using _02.kanban.Application.Implementation;
using _02.kanban.Application.Interfaces.Application;

namespace _01.kanban.WebApi.Extensions
{
    public static class InjectionsApplicationExtension
    {
        public static void AddInjectionApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IBoardApplication, BoardApplication>();
            services.AddScoped<ICardApplication, CardApplication>();
            services.AddScoped<IDepartamentApplication, DepartamentApplication>();
            services.AddScoped<IStatusApplication, StatusApplication>();
        }
    }
}