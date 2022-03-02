using _01.kanban.WebApi.Extensions;
using _03.kanban.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string allowSpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddDefaultCorsPolicy(allowSpecificOrigins);
builder.Services.AddDbContext<kanbanContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddJwtAuthentication(builder.Configuration.GetSection("JWT"));
builder.Services.AddInjectionApplication();
builder.Services.AddInjectionRepository();
builder.Services.AddAutoMapperExtension();
builder.Services.AddValidators();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseCors(allowSpecificOrigins);
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
