using course.api.Business.Entities;
using course.api.Configuratioins;
using course.api.Filters;
using course.api.Models;
using course.api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace course.api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IUserRepository userRepository,
            IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Método API para log-in de USUÁRIOS
        /// </summary>
        /// <param name="loginViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "SUCESSO na Autenticação!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos OBRIGATÓRIOS!", Type = typeof(ValidaCampoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "ERRO na Autenticação!", Type = typeof(ValidaCampoViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidacaoModelStateCustom]
        public IActionResult Logmein(LoginViewModelInput loginViewModelInput)
        {
            var user = _userRepository.ObterUsuario(loginViewModelInput.Login);

            if (user == null)
            {
                return BadRequest("Houve um Erro ao Tentar Acessar.");
            }
            var userViewModelOutput = new UserViewModelOutput()
            {
                CodeID = user.UserId,
                Login = loginViewModelInput.Login,
                Email = user.Email
            };

            var token = _authenticationService.GenerateToken(userViewModelOutput);

            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        /// <summary>
        /// Método API para registro de USUÁRIOS
        /// </summary>
        /// <param name="registerViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "SUCESSO no Registro!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos OBRIGATÓRIOS!", Type = typeof(ValidaCampoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "ERRO no Registro!", Type = typeof(ValidaCampoViewModel))]
        [HttpPost]
        [Route("register")]
        [ValidacaoModelStateCustom]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            var user = new User();
            user.Login = registerViewModelInput.Login;
            user.Password = registerViewModelInput.Password;
            user.Email = registerViewModelInput.Email;


            _userRepository.Add(user);
            _userRepository.Commit();

            return Created("SUCCESS!!", registerViewModelInput);
        }
    }
}
