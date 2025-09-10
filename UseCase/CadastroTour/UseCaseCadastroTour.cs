using Prova2.Models;
using Prova2.UseCase.CadastroTour;

namespace Prova2.UseCase.Cadastro;

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
