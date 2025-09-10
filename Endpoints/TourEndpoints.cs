using Microsoft.AspNetCore.Mvc;
using Prova2.UseCase.CadastroTour;
using Prova2.UseCase.Editar;
using Prova2.UseCase.GetTour;

namespace Prova2.Endpoints;

public static class TourEndpoints
{
    public static void ConfigureTourEndpoints(this WebApplication app)
    {
        app.MapGet("tour/{id}", async (
            Guid id,
            [FromServices] UseCaseGetTour useCase) =>
            {
                var payload = new PayloadGetTour(id);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Tour not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };

            });

        app.MapPost("tour", async (
            [FromBody] PayloadCadastroTour payload,
            [FromServices] UseCaseCadastroTour useCase) =>
            {
                var result = await useCase.Do(payload);

                if (result.IsSuccess)
                    return Results.Created();

                return Results.BadRequest(result.Reason);
            });

        app.MapPut("tour", async (
            [FromBody] PayloadEditar payload,
            [FromServices] UseCaseEditar useCase) =>
            {
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Tour not found") => Results.NotFound(),
                    (false, "Password invalid") => Results.Unauthorized(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok()
                };
            });
    }
}