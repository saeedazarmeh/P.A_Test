using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using P.A_Service.Users.Contracts.DTOs;

namespace P.A_API.JWT
{
    public class JwtTokenBuilder
    {
        public static string BuildToken(UserResultDTO user, int activeDurationToken)
        {
            var builder = WebApplication.CreateBuilder();
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:SignInKey"]));
            //Hash Secret key
            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: builder.Configuration["JwtConfig:Issuer"],
                audience: builder.Configuration["JwtConfig:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(activeDurationToken),
                signingCredentials: credential);

            //Create JWT Token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
