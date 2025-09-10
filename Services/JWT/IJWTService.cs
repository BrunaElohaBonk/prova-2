namespace Prova2.Services.JWT;

public interface IJWTService
{
    string CreateToken(UserToAuth data);
}