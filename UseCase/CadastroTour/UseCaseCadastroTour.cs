using Prova2.Models;

namespace Prova2.UseCase.CadastroTour;

public class UseCaseCadastroTour(provaDbContext ctx)
{
    public async Task<Results<CadastroTourResponse>> Do(PayloadCadastroTour payload)
    {
        var tour = new Tour
        {
            Title = payload.Title,
            Description = payload.Description
        };
    }
}
