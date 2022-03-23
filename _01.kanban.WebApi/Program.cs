using _01.kanban.WebApi.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

string allowSpecificOrigins = "_allowSpecificOrigins";

builder.Services.AddDatabaseConnection(builder.Configuration);
builder.Services.AddDefaultCorsPolicy(allowSpecificOrigins);
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
app.UseDatabaseExtencion();
app.UseSerilogRequestLogging();

app.UseCors(allowSpecificOrigins);
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.MapFallbackToFile("index.html"); ;

app.Run();
