using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoConnectBackend.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DoConnectBackend.Services;

public class JwtOptions
{
    public string Key { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public int ExpiryMinutes { get; set; } = 120;
}

public interface ITokenService
{
    string Create(User user);
}

public class TokenService : ITokenService
{
    private readonly JwtOptions _opt;
    public TokenService(IOptions<JwtOptions> opt) { _opt = opt.Value; }

    public string Create(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_opt.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var jwt = new JwtSecurityToken(_opt.Issuer, _opt.Audience, claims,
            expires: DateTime.UtcNow.AddMinutes(_opt.ExpiryMinutes), signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
