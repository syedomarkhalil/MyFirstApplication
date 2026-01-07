using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TvFlixApp.Application.Contracts;
using TvFlixApp.Application.Models;

namespace TvFlixApp.Application.Helpers
{

    public class JwtTokenService: IJwtTokenService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly IHttpContextAccessor _user;
        public JwtTokenService(IOptions<AppSettings> settings, IHttpContextAccessor user)
        {
            _settings = settings;
            _user = user;
        }       

        public string GenerateToken()
        {
            
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.JWTTokenSettings?.JwtSecretKey!));

            var credentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            //Token expiry
            var expiry = DateTime.UtcNow.AddMinutes(1);
            int ts = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;
            
            var userName = _user.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var userEmail = _user.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var sub = _user.HttpContext.User.Identity?.AuthenticationType;
            var iss = _settings.Value.JWTTokenSettings?.IssuerUrl;
            var aud = _settings.Value.JWTTokenSettings?.ResourceUrl;

            //Payload
            var payLoad = new JwtPayload
            {
                { "sub", sub },
                {"Name", userName },
                {"email",userEmail },
                {"exp",ts },
                {"iss", iss },
                {"aud",aud }

            };
            var secToken = new JwtSecurityToken(header, payLoad);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);
            return tokenString;
        }
    }
}
