using course.api.Filters;
using course.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace course.api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [SwaggerResponse(statusCode: 200, description: "SUCESSO na Autenticação!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos OBRIGATÓRIOS!", Type = typeof(ValidaCampoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "ERRO na Autenticação!", Type = typeof(ValidaCampoViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidacaoModelStateCustom]
        public IActionResult Logmein(LoginViewModelInput loginViewModelInput)
        {
            var userViewModelOutput = new UserViewModelOutput()
            {
                CodeID = 1,
                Login = "mihainuan",
                Email = "mihainuan@gmail.com"
            };

            var secret = Encoding.ASCII.GetBytes("MNaAlpB%&<!P@LOO$@!>777*H3lp?#");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.CodeID.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, userViewModelOutput.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        [SwaggerResponse(statusCode: 200, description: "SUCESSO no Registro!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos OBRIGATÓRIOS!", Type = typeof(ValidaCampoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "ERRO no Registro!", Type = typeof(ValidaCampoViewModel))]
        [HttpPost]
        [Route("register")]
        [ValidacaoModelStateCustom]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            //}

            return Created("", registerViewModelInput);
        }
    }
}
