using CQRS.BankApp.Core.Domains.UserDomain.Queries;
using CQRS.BankApp.Core.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CQRS.BankApp.Core.Services
{
    public class JWTTokenService
    {
        public string GenerateJWT(LoginQuery login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Consts.JWTKEY));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: Consts.Issuer,
                audience: Consts.Audience,
                expires: Consts.TokenExpirationTime,
                claims: new List<Claim> { new Claim(ClaimTypes.Role, Consts.UserRole) },
                signingCredentials: credentials
            );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodeToken;
        }
    }
}
