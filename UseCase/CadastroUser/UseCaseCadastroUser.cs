using Prova2.Models;
using Prova2.Services.Password;
using Prova2.Services.Users;

namespace Prova2.UseCase.CadastroUser;

public class UseCaseCadastroUser
(
    IUserService userService,
    IPasswordService passwordService
)
{
    public async Task<Result<ResponseCadastroUser>> Do(PayloadCadastroUser payload)
    {
        var user = new User
        {
            Name = payload.Name,
            UserName = payload.UserName,
            Password = passwordService.Hash(payload.Password)
        };

        await userService.Create(user); 

        return Result<ResponseCadastroUser>.Success(new());
    }
}