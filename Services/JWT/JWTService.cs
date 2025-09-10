using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Prova2.Services.JWT;

// implementa a interface para criar o jwt (código padrão)
public class JWTService : IJWTService
{
    public string CreateToken(UserToAuth data)
    {
        var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
        var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
        var key = new SymmetricSecurityKey(keyBytes);
        
        var jwt = new JwtSecurityToken(
            claims: [
                new Claim(ClaimTypes.NameIdentifier, data.UserId.ToString()),
                new Claim(ClaimTypes.Name, data.Name),
                new Claim(ClaimTypes.UserName, data.UserName)
            ],
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256Signature
            )
        );
        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(jwt);
    }
}