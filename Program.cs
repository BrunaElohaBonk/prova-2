using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using Prova2.Models;
using Prova2.UseCase.Cadastro;
using Prova2.UseCase.Editar;
using Prova2.UseCase.GetTour;
using Prova2.UseCase.Login;
using Prova2.Services.JWT;
using Prova2.Services.Password;
using Prova2.Services.Users;
using Prova2.Endpoints;

var builder = WebApplication.CreateBuilder(args);

object value = builder.Services.AddDbContext<provaDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddTransient<IPasswordService, PBKDF2PasswordService>();
builder.Services.AddTransient<IUserService, EFUserService>();
builder.Services.AddSingleton<IJWTService, JWTService>();

builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<GetTourUseCase>();
builder.Services.AddTransient<EditarUseCase>();
builder.Services.AddTransient<CadastroUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "rplace-app",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureAuthEndpoints();
app.ConfigureTourEndpoints();
app.ConfigureUserEndpoints();

app.Run();