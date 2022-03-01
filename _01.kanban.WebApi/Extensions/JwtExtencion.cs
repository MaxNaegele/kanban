using System.Text;
using _02.kanban.Application.Interfaces.Services;
using _03.kanban.Data.Service;
using _04.kanban.Core.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace _01.kanban.WebApi.Extensions;

public static class JwtExtensions
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDataUserLogged, DataUserLogged>();
        services.AddSingleton<ITokenService, TokenService>();
        services.Configure<JwtOptions>(configuration);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration[nameof(JwtOptions.Secret)])),
                ValidateIssuer = true,
                ValidIssuer = configuration[nameof(JwtOptions.Issuer)],
                ValidateAudience = true,
                ValidAudience = configuration[nameof(JwtOptions.Audience)],
                ValidateLifetime = true,
            };
        });

    }
}