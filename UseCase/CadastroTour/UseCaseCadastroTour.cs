using Prova2.Models;

namespace Prova2.UseCase.CadastroTour;

public class CadastroUseCase(provaDbContext ctx)
{
    public async Task<Results<ResponseCadastroTour>> Do(PayloadCadastroTour payload)
    {
        var tour = new Tour
        {
            Title = payload.Title,
            Description = payload.Description
        };
    }
}
