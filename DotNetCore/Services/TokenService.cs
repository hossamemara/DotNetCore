using DotNetCore.ConfigurationClasses;
using DotNetCore.DataContext;
using DotNetCore.DBContext;
using DotNetCore.Entities;
using DotNetCore.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DotNetCore.Services
{
    public class TokenService(IOptionsSnapshot<JwtOptions> optionsSnapshot) : IToken
    {
        public TokenResponse GetUserToken(AuthenticationRequest request, User user, List<Role> roleNames)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptors = new SecurityTokenDescriptor()
            {
                Issuer = optionsSnapshot.Value.Issuer,
                Audience = optionsSnapshot.Value.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(optionsSnapshot.Value.SigningKey)), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Country, user.Country),
                }.Concat(roleNames.Select(r => new Claim(ClaimTypes.Role, r.RoleName))))

            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptors);
            var accessToke = tokenHandler.WriteToken(securityToken);
            return new TokenResponse { 
            Token = accessToke           
            };
        }
    }
}
