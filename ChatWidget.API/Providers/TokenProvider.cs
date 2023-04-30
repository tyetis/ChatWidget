using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChatWidget.API.Providers
{
    public class TokenProvider : ITokenProvider
    {
        private IHttpContextAccessor ContextAccessor { get; set; }
        private readonly string SigningKey = "0c6855ca-ddc1-42c7-b681-6d912ce6798c";

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            ContextAccessor = contextAccessor;
        }

        public string CreateToken(Guid userId, Guid inboxId)
        {
            Claim[] claims = new[]
            {
                new Claim("UserId", userId.ToString()),
                new Claim("InboxId", inboxId.ToString()),
            };
            //TODO: issuer, audience appsettings den çekilecek
            var token = new JwtSecurityToken
            (
                issuer: "TalkBotWebAPI",
                audience: "browserUser",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(6), // saat geçerli olacak
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey)), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public Guid? UserId
        {
            get
            {
                Claim claim = ContextAccessor.HttpContext.User.Claims.Where(n => n.Type == "UserId").FirstOrDefault();
                if (claim != null) return Guid.Parse(claim.Value);
                else return null;
            }
        }
        public Guid? InboxId
        {
            get
            {
                Claim claim = ContextAccessor.HttpContext.User.Claims.Where(n => n.Type == "InboxId").FirstOrDefault();
                if (claim != null) return Guid.Parse(claim.Value);
                else return null;
            }
        }
    }
}
