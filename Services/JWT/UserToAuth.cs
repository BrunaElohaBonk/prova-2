namespace Prova2.Services.JWT;

public record UserToAuth(
    Guid UserId,
    string Name,
    string UserName
);