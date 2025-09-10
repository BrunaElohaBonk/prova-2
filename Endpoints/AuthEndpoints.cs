using Microsoft.AspNetCore.Mvc;
using Prova2.UseCase.Login;

namespace Prova2.Endpoints;

public static class AuthEndpoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("auth", async (
            [FromBody]PayloadLogin payload,
            [FromServices]LoginUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            
            return Results.Ok(result.Data);
        });
    }
}