using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Settings;

namespace Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthSettings _authSettings;

        public AuthService(IOptions<AuthSettings> settings)
        {
            _authSettings = settings.Value;
        }

        public string GenerateToken(Guid id, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, id.ToString()),
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                _authSettings.Issuer,
                audience: _authSettings.Audience,
                notBefore: now,
                claims: claimsIdentity.Claims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Key)),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}