﻿using course.api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace course.api.Configuratioins
{
    public class JwtService : IAuthenticationService
    {

        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            configuration = _configuration;
        }

        public string GenerateToken(UserViewModelOutput userViewModelOutput)
        {
            //var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value); 
            //TODO: Check why the config is not being read above

            var secret = Encoding.ASCII.GetBytes("MNaAlpB%&<!P@LOO$@!>777*H3lp?#");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.CodeID.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelOutput.Login .ToString()),
                    new Claim(ClaimTypes.Email, userViewModelOutput.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }
    }
}
