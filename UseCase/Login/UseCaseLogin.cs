using Prova2.Services.JWT;
using Prova2.Services.Password;
using Prova2.Services.Users;

namespace Prova2.UseCase.Login;

public class LoginUseCase(
    IUserService userService,
    IPasswordService passwordService,
    IJWTService jWTService
)
{ 
    public async Task<Result<ResponseLogin>> Do(PayloadLogin payload)
    {
        var user = await userService.FindByLogin(payload.Login); 
        if (user is null) 
            return Result<ResponseLogin>.Fail("User not found");

        var passwordMatch = passwordService 
            .Compare(payload.Password, user.Password);

        if (!passwordMatch) 
            return Result<ResponseLogin>.Fail("User not found");

        var jwt = jWTService.CreateToken(new(
            user.ID, user.Name, user.Username
        )); 

        return Result<ResponseLogin>.Success(new ResponseLogin(jwt));
    }
}
