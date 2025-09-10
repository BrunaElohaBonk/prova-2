using Microsoft.EntityFrameworkCore;
using Prova2.Models;

namespace Prova2.Services.Users;

// implementa a interface
public class EFUserService(provaDbContext ctx) : IUserService
{
    public async Task<Guid> Create(User user)
    {
        ctx.Users.Add(user); 
        await ctx.SaveChangesAsync(); 
        return user.ID; 
    }

    public async Task<User> FindByLogin(string login)
    {
        var user = await ctx.Users.FirstOrDefaultAsync( 
            p => p.UserName == login || p.Name == login 
        ); 
        return user; 
    }
}