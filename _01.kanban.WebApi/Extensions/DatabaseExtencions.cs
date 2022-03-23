using _03.kanban.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace _01.kanban.WebApi.Extensions
{
    public static class DatabaseExtencions
    {
        public static void AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<kanbanContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void UseDatabaseExtencion(this IApplicationBuilder app)
        {
                using var serviceScoped = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                using var context = serviceScoped.ServiceProvider.GetService<kanbanContext>();
                context.Database.Migrate(); // executa as migrations 
                context.Database.EnsureCreated(); // garante que a base de dados seja criada
        }
    }
}