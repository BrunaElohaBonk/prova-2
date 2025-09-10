using Microsoft.AspNetCore.Mvc;
using Prova2.UseCase.Cadastro;
using Prova2.UseCase.CadastroUser;
using Prova2.UseCase.Editar;
using Prova2.UseCase.GetTour;
using Prova2.UseCase.Login;

namespace Prova2.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapPost("user", async (
            [FromBody] PayloadCadastroUser payload,
            [FromServices] UseCaseCadastroUser useCase) => 
            {
                var result = await useCase.Do(payload);
                if (result.IsSuccess)
                    return Results.Created(); 

                return Results.BadRequest(result.Reason); 
        });
    }
}