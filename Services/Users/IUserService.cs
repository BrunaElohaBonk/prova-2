using Prova2.Models;

namespace Prova2.Services.Users;

// serviços para o perfil
public interface IUserService
{
    Task<User> FindByLogin(string login);
    Task<Guid> Create(User user);
}