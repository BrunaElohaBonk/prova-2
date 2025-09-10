using Prova2.Models;
using Prova2.UseCase.Cadastro;

namespace Prova2.UseCase.Cadastro;

public class CadastroUseCase(provaDbContext ctx)
{
    public async Task<Results<CadastroResponse>> Do(PayloadCadastro payload)
    {
        var tour = new Tour
        {
            Title = payload.Title,
            Description = payload.Description
        };
    }
}
