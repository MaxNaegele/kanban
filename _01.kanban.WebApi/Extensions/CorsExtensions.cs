namespace _01.kanban.WebApi.Extensions
{
    public static class CorsExtensions
    {
        public static void AddDefaultCorsPolicy(this IServiceCollection services, string specification)
        {
          services.AddCors(options =>
            {
                options.AddPolicy(specification, b =>
                {
                    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }
    }
}