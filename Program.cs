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

var builder = WebApplication.CreateBuilder(args);

object value = builder.Services.AddDbContext<provaDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});