using _01.kanban.WebApi.Extensions;
using _03.kanban.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<kanbanContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddInjectionRepository();
builder.Services.AddInjectionApplication();
builder.Services.AddJwtAuthentication(builder.Configuration);
// Add services to the container.


builder.Services.AddControllersWithViews(options =>
{
   var policy = new AuthorizationPolicyBuilder()
       .RequireAuthenticatedUser()
       .Build();

   options.Filters.Add(new AuthorizeFilter(policy));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
